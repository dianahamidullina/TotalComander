using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.IO.Compression.ZipFile;

namespace TotalCommanderWinForms
{
    public partial class MainWindow : Form
    {
        private static string prohibitedSymbols;
        private static string dateFormat;
        private WindowSide side;
        private Button[] lowerButtons;
        private FileSystemWatcher leftFileWatcher;
        private FileSystemWatcher rightFileWatcher;
        private bool readDefaultExecuted = false;
        static MainWindow()
        {
            prohibitedSymbols = "\\|/*:?\"<>";
            dateFormat = "dd.MM.yyyy HH:mm:ss";
        }

        public MainWindow()
        {
           //Настройка FileSystemWatcher
            leftFileWatcher = new FileSystemWatcher();
            leftFileWatcher.Renamed += (object sender, RenamedEventArgs e) =>
            {
                //Делаю через Action, так как FileSystemWatcher исполняется в другом потоке
                Action act = () =>
                {
                    LoadFilesFromDirectory(leftDataView.Tag as DirectoryInfo, leftDataView);
                };
                Invoke(act);
            };
            rightFileWatcher = new FileSystemWatcher();
            rightFileWatcher.Renamed += (object sender, RenamedEventArgs e) =>
            {
                //Делаю через Action, так как FileSystemWatcher исполняется в другом потоке
                Action act = () =>
                {
                    LoadFilesFromDirectory(rightDataView.Tag as DirectoryInfo, rightDataView);
                };
                Invoke(act);
            };
          
            side = WindowSide.Left;
            InitializeComponent();
            leftDataView.AutoSizeRowsMode = rightDataView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            lowerButtons = new Button[5] { copyBtn, transferBtn, pasteBtn, deleteBtn, createDirBtn };
            leftDataView.Click += new EventHandler((sender, e) => { side = WindowSide.Left; });
            rightDataView.Click += new EventHandler((sender, e) => { side = WindowSide.Right; });
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo info in DriveInfo.GetDrives())
            {
                leftDiskDropDown.Items.Add(info);
                rightDiskDropDown.Items.Add(info);
            }
            leftDiskDropDown.SelectedIndex = rightDiskDropDown.SelectedIndex = 0;
            OnLowerPanelSizeChanged(null, null);
           // Чтение прошлой открытой папки
            if (File.Exists("DefaultDirectories.txt"))
            {
                string[] paths = File.ReadAllLines("DefaultDirectories.txt");
                if (paths.Length >= 2)
                {
                    if (Directory.Exists(paths[0]))
                    {
                        DirectoryInfo leftInfo = new DirectoryInfo(paths[0]);
                        LoadFilesFromDirectory(leftInfo, leftDataView);
                    }

                    if (Directory.Exists(paths[1]))
                    {
                        DirectoryInfo rightInfo = new DirectoryInfo(paths[1]);
                        LoadFilesFromDirectory(rightInfo, rightDataView);
                    }
                }
            }
            readDefaultExecuted = true;
           
            leftFileWatcher.EnableRaisingEvents = rightFileWatcher.EnableRaisingEvents = true; //<-- Включение получения ивентов от FileSystemWatcher
        }

        // Win32
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }
   

       //ForContextMenu
        public ContextMenuStrip CreateFileRowStrip(DataGridViewRow row, FileInfo info)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.ShowImageMargin = contextMenuStrip.ShowCheckMargin = false;
         
            ToolStripButton propButton = new ToolStripButton("Свойства");
            propButton.Click += (object sender, EventArgs e) =>
            {
                ShowFileProperties(info.FullName);
            };
           

        
            ToolStripButton openButton = new ToolStripButton("Открыть");
            openButton.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    Process.Start(info.FullName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Ошибка запуска файла: \n{exception}", "Ошибка запуска");
                }
            };

            ToolStripButton renameButton = new ToolStripButton("Переименовать");
            renameButton.Size = new Size(78, renameButton.Height);
            renameButton.Click += (object sender, EventArgs e) =>
            {
                row.DataGridView.CurrentCell = row.Cells[1];
                row.DataGridView.BeginEdit(true);
            };
       
            contextMenuStrip.Items.Add(propButton);
            contextMenuStrip.Items.Add(openButton);
            contextMenuStrip.Items.Add(renameButton);
            return contextMenuStrip;
        }

        public ContextMenuStrip CreateDirectoryRowStrip(DataGridViewRow row, DirectoryInfo info)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.ShowImageMargin = contextMenuStrip.ShowCheckMargin = false;
       
            ToolStripButton propButton = new ToolStripButton("Свойства");
            propButton.Click += (object sender, EventArgs e) =>
            {
                ShowFileProperties(info.FullName);
            };
        

         
            ToolStripButton openButton = new ToolStripButton("Открыть");
            openButton.Click += (object sender, EventArgs e) =>
            {
                LoadFilesFromDirectory(info, row.DataGridView);
                if (info.Parent != null && info.Parent.FullName.Equals(info.FullName))
                {
                    foreach (DataGridViewRow rowFromGrid in row.DataGridView.Rows)
                    {
                        DirectoryInfo rowDirectoryInfo = rowFromGrid.Tag as DirectoryInfo;
                        rowFromGrid.Selected = rowDirectoryInfo != null && rowDirectoryInfo.FullName.Equals(info.FullName);
                    }
                }
            };
         

            ToolStripButton renameButton = new ToolStripButton("Переименовать");
            renameButton.Size = new Size(78, renameButton.Height);
            renameButton.Click += (object sender, EventArgs e) =>
            {
                row.DataGridView.CurrentCell = row.Cells[1];
                row.DataGridView.BeginEdit(true);
            };
      
            contextMenuStrip.Items.Add(propButton);
            contextMenuStrip.Items.Add(openButton);
            contextMenuStrip.Items.Add(renameButton);
            return contextMenuStrip;
        }
   

   
        private void LoadFilesFromDisk(DriveInfo currentDrive, DataGridView gridView)
        {
            foreach (string directoryPath in Directory.GetDirectories(currentDrive.Name))
            {
                DirectoryInfo info = new DirectoryInfo(directoryPath);
                DataGridViewRow row = new DataGridViewRow();
                row.ContextMenuStrip = CreateDirectoryRowStrip(row, info);
                row.CreateCells(gridView);
                row.Tag = info;
                row.SetValues(new object[6] { DefaultIcons.Folder, info.Name, "<DIR>", (long)0, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                gridView.Rows.Add(row);
            }

            foreach (string filePath in Directory.GetFiles(currentDrive.Name))
            {
                FileInfo info = new FileInfo(filePath);
                DataGridViewRow row = new DataGridViewRow();
                row.ContextMenuStrip = CreateFileRowStrip(row, info);
                row.CreateCells(gridView);
                row.Tag = info;
                row.SetValues(new object[6] { Icon.ExtractAssociatedIcon(info.FullName), Path.GetFileNameWithoutExtension(info.Name), info.Extension, info.Length, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                gridView.Rows.Add(row);
            }
            gridView.Tag = new DirectoryInfo(currentDrive.Name);
            if (gridView == leftDataView)
            {
                leftPathInfo.Text = $"Путь: {currentDrive.Name}";
            }
            else if (gridView == rightDataView)
            {
                rightPathInfo.Text = $"Путь: {currentDrive.Name}";
            }
            OverWriteDefaultPaths();
        }

        private void LoadFilesFromDirectory(DirectoryInfo currentDirectory, DataGridView gridView)
        {
            
            if (!currentDirectory.FullName.EndsWith(":\\"))
            {
                //^
                //| Проверка является ли директория диском, так как для диска выписывается ограничение доступа
                try
                {
                    //Добавить Try-Catch блок, так как для некоторых папок невозможно определить права доступа (Такие папки, как Config.MSI) и выдаёт исключение
                    DirectorySecurity securityInfo = Directory.GetAccessControl(currentDirectory.FullName);
                    if (securityInfo.AreAccessRulesProtected)
                    {
                        MessageBox.Show("Программа не имеет доступа к этой папке", "Ошибка доступа");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Программа не может получить права доступа к этой папке", "Ошибка");
                    return;
                }
            }
            gridView.Rows.Clear();
            if (currentDirectory.Parent != null)
            {
                DataGridViewRow rowInsert = new DataGridViewRow();
                rowInsert.CreateCells(gridView);
                rowInsert.Tag = currentDirectory.Parent;
                rowInsert.SetValues(new object[6] { SystemIcons.Exclamation, "[Назад]", null, null, null, null });
                rowInsert.Cells[1].ReadOnly = true;
                gridView.Rows.Add(rowInsert);
            }

            foreach (string directoryPath in Directory.GetDirectories(currentDirectory.FullName))
            {
                DirectoryInfo info = new DirectoryInfo(directoryPath);
                DataGridViewRow row = new DataGridViewRow();
                row.ContextMenuStrip = CreateDirectoryRowStrip(row, info);
                row.CreateCells(gridView);
                row.Tag = info;
                row.SetValues(new object[6] { DefaultIcons.Folder, info.Name, "<DIR>", (long)0, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                gridView.Rows.Add(row);
            }

            foreach (string filePath in Directory.GetFiles(currentDirectory.FullName))
            {
                FileInfo info = new FileInfo(filePath);
                DataGridViewRow row = new DataGridViewRow();
                row.ContextMenuStrip = CreateFileRowStrip(row, info);
                row.CreateCells(gridView);
                row.Tag = info;
                row.SetValues(new object[6] { Icon.ExtractAssociatedIcon(info.FullName), Path.GetFileNameWithoutExtension(info.Name), info.Extension, info.Length, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                gridView.Rows.Add(row);
            }
            gridView.Tag = currentDirectory;
            if (gridView == leftDataView)
            {
                leftPathInfo.Text = $"Путь: {currentDirectory.FullName}";
            }
            else if (gridView == rightDataView)
            {
                rightPathInfo.Text = $"Путь: {currentDirectory.FullName}";
            }
            OverWriteDefaultPaths();
        }
       

        public void CopyToClipboard()
        {
            DataGridViewRowCollection rowCollection = null;
            switch (side)
            {
                case WindowSide.Left:
                    rowCollection = leftDataView.Rows;
                    break;
                case WindowSide.Right:
                    rowCollection = rightDataView.Rows;
                    break;
            }
            if (rowCollection != null)
            {
                StringCollection CopyCollection = new StringCollection();
                foreach (DataGridViewRow row in rowCollection)
                {
                    if (row.Selected && row.Cells[2].Value != null)
                    {
                        FileInfo fileInfo = row.Tag as FileInfo;
                        DirectoryInfo dirInfo = row.Tag as DirectoryInfo;
                        if (fileInfo != null)
                        {
                            CopyCollection.Add(fileInfo.FullName);
                        }
                        else if (dirInfo != null)
                        {
                            CopyCollection.Add(dirInfo.FullName);
                        }
                    }
                }
                Clipboard.SetFileDropList(CopyCollection);
            }
        }

        public void InsertFromClipboard()
        {
            DataGridView dataVeiw = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiw = leftDataView;
                    break;
                case WindowSide.Right:
                    dataVeiw = rightDataView;
                    break;
            }
            if (dataVeiw != null)
            {
                StringCollection CopyCollection = Clipboard.GetFileDropList();
                DirectoryInfo currentDirectory = dataVeiw.Tag as DirectoryInfo;
                foreach (string path in CopyCollection)
                {
                    if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                    {
                        try
                        {
                            CopyDirectory(new DirectoryInfo(path), currentDirectory);
                        }
                        catch
                        {
                            MessageBox.Show($"Путь {path} невозможно скопировать или он был скопирован неполностью");
                            continue;
                        }
                    }
                    else
                    {
                        FileInfo info = new FileInfo(path);
                        info.CopyTo($"{currentDirectory.FullName}\\{info.Name}");
                    }
                }
                if (CopyCollection.Count > 0)
                {
                    LoadFilesFromDirectory(currentDirectory, dataVeiw);
                }
            }
        }
      

        private void OnTransferClick(object sender, EventArgs e)
        {
            DataGridView dataVeiwSender = null;
            DataGridView dataVeiwReceiver = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiwSender = leftDataView;
                    dataVeiwReceiver = rightDataView;
                    break;
                case WindowSide.Right:
                    dataVeiwSender = rightDataView;
                    dataVeiwReceiver = leftDataView;
                    break;
            }
            if (dataVeiwSender != null && dataVeiwReceiver != null)
            {
                DirectoryInfo receiverDirectory = dataVeiwReceiver.Tag as DirectoryInfo;
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dataVeiwSender.Rows)
                {
                    if (row.Selected && row.Cells[2].Value != null)
                    {
                        FileInfo fileInfo = row.Tag as FileInfo;
                        DirectoryInfo dirInfo = row.Tag as DirectoryInfo;
                        if (fileInfo != null)
                        {
                            FileInfo info = null;
                            try
                            {
                                if (receiverDirectory.FullName.EndsWith("\\"))
                                {
                                    //Заначит это диск
                                    fileInfo.MoveTo($"{receiverDirectory.FullName}{fileInfo.Name}");
                                    info = new FileInfo($"{receiverDirectory.FullName}{fileInfo.Name}");
                                }
                                else
                                {
                                    //Значит это директория
                                    fileInfo.MoveTo($"{receiverDirectory.FullName}\\{fileInfo.Name}");
                                    info = new FileInfo($"{receiverDirectory.FullName}\\{fileInfo.Name}");
                                }
                            }
                            catch
                            {
                                MessageBox.Show($"Ошибка копирования файла {fileInfo.FullName}", "Ошибка");
                                continue;
                            }
                            DataGridViewRow newRow = new DataGridViewRow();
                            newRow.CreateCells(dataVeiwReceiver);
                            newRow.Tag = info;
                            newRow.SetValues(new object[6] { Icon.ExtractAssociatedIcon(info.FullName), Path.GetFileNameWithoutExtension(info.Name), info.Extension, info.Length, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                            dataVeiwReceiver.Rows.Add(newRow);
                            rowsToDelete.Add(row);
                        }
                        else if (dirInfo != null)
                        {
                            if (dirInfo.FullName.Equals(receiverDirectory.FullName))
                            {
                                MessageBox.Show("Невозможно копировать папку саму в себя", "Ошибка");
                                return;
                            }
                            if (!receiverDirectory.GetDirectories().Select(x => x.FullName).Any(x => x.Equals(dirInfo.FullName)))
                            {
                                DirectoryInfo info;
                                try
                                {
                                    if (dirInfo.FullName.EndsWith("\\"))
                                    {
                                        dirInfo.MoveTo($"{receiverDirectory.FullName}{dirInfo.Name}");
                                        info = new DirectoryInfo($"{receiverDirectory}{dirInfo.Name}");
                                    }
                                    else
                                    {
                                        dirInfo.MoveTo($"{receiverDirectory.FullName}\\{dirInfo.Name}");
                                        info = new DirectoryInfo($"{receiverDirectory}\\{dirInfo.Name}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Ошибка копирования папки {dirInfo.FullName} {ex}", "Ошибка");
                                    continue;
                                }
                                DataGridViewRow newRow = new DataGridViewRow();
                                newRow.CreateCells(dataVeiwReceiver);
                                newRow.Tag = info;
                                newRow.SetValues(new object[6] { DefaultIcons.Folder, info.Name, "<DIR>", (long)0, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                                dataVeiwReceiver.Rows.Add(newRow);
                                rowsToDelete.Add(row);
                            }
                            else
                            {
                                MessageBox.Show($"Папка с именем '{dirInfo.Name}' уже существует в '{receiverDirectory.FullName}'", "Ошибка");
                            }
                        }
                    }
                }
                rowsToDelete.ForEach(x => dataVeiwSender.Rows.Remove(x));
            }
        }

        private void OnCopyClick(object sender, EventArgs e)
        {
            DataGridView dataVeiwSender = null;
            DataGridView dataVeiwReceiver = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiwSender = leftDataView;
                    dataVeiwReceiver = rightDataView;
                    break;
                case WindowSide.Right:
                    dataVeiwSender = rightDataView;
                    dataVeiwReceiver = leftDataView;
                    break;
            }
            if (dataVeiwSender != null && dataVeiwReceiver != null)
            {
                DirectoryInfo receiverDirectory = dataVeiwReceiver.Tag as DirectoryInfo;
                foreach (DataGridViewRow row in dataVeiwSender.Rows)
                {
                    if (row.Selected && row.Cells[2].Value != null)
                    {
                        FileInfo fileInfo = row.Tag as FileInfo;
                        DirectoryInfo dirInfo = row.Tag as DirectoryInfo;
                        if (fileInfo != null)
                        {
                            FileInfo info = null;
                            try
                            {
                                if (receiverDirectory.FullName.EndsWith("\\"))
                                {
                                    //Заначит это диск
                                    fileInfo.CopyTo($"{receiverDirectory.FullName}{fileInfo.Name}");
                                    info = new FileInfo($"{receiverDirectory.FullName}{fileInfo.Name}");
                                }
                                else
                                {
                                    //Значит это директория
                                    fileInfo.CopyTo($"{receiverDirectory.FullName}\\{fileInfo.Name}");
                                    info = new FileInfo($"{receiverDirectory.FullName}\\{fileInfo.Name}");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка копирования файла {fileInfo.FullName}\n{ex.Message}", "Ошибка");
                                continue;
                            }
                            DataGridViewRow newRow = new DataGridViewRow();
                            newRow.CreateCells(dataVeiwReceiver);
                            newRow.Tag = info;
                            newRow.SetValues(new object[6] { Icon.ExtractAssociatedIcon(info.FullName), Path.GetFileNameWithoutExtension(info.Name), info.Extension, info.Length, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                            dataVeiwReceiver.Rows.Add(newRow);
                        }
                        else if (dirInfo != null)
                        {
                            if (dirInfo.FullName.Equals(receiverDirectory.FullName))
                            {
                                MessageBox.Show("Невозможно копировать папку саму в себя", "Ошибка");
                                return;
                            }
                            if (!receiverDirectory.GetDirectories().Select(x => x.FullName).Any(x => x.Equals(dirInfo.FullName)))
                            {
                                try
                                {
                                    CopyDirectory(dirInfo, receiverDirectory);
                                }
                                catch
                                {
                                    MessageBox.Show($"Ошибка копирования файла {fileInfo.FullName}", "Ошибка");
                                    continue;
                                }
                                DirectoryInfo info = new DirectoryInfo($"{receiverDirectory}\\{dirInfo.Name}");
                                DataGridViewRow newRow = new DataGridViewRow();
                                newRow.CreateCells(dataVeiwReceiver);
                                newRow.Tag = info;
                                newRow.SetValues(new object[6] { DefaultIcons.Folder, info.Name, "<DIR>", (long)0, info.LastWriteTime.ToString(dateFormat), info.Attributes });
                                dataVeiwReceiver.Rows.Add(newRow);
                            }
                            else
                            {
                                MessageBox.Show($"Папка с именем '{dirInfo.Name}' уже существует в '{receiverDirectory.FullName}'", "Ошибка");
                            }
                        }
                    }
                }
            }
        }

        private void OnPasteClick(object sender, EventArgs e)
        {
            InsertFromClipboard();
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            DataGridView dataVeiw = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiw = leftDataView;
                    break;
                case WindowSide.Right:
                    dataVeiw = rightDataView;
                    break;
            }
            if (dataVeiw != null)
            {
                List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dataVeiw.Rows)
                {
                    if (row.Selected && row.Cells[2].Value != null)
                    {
                        FileInfo fileInfo = row.Tag as FileInfo;
                        DirectoryInfo dirInfo = row.Tag as DirectoryInfo;
                        if (fileInfo != null)
                        {
                            try
                            {
                                fileInfo.Delete();
                                rowsToDelete.Add(row);
                            }
                            catch
                            {
                                MessageBox.Show($"Не удалось удалить файл {fileInfo.FullName}", "Ошибка");
                            }
                        }
                        else if (dirInfo != null)
                        {
                            try
                            {
                                dirInfo.Delete(true);
                                rowsToDelete.Add(row);
                            }
                            catch
                            {
                                MessageBox.Show($"Не удалось удалить папку {dirInfo.FullName} ", "Ошибка");
                            }
                        }
                    }
                }
                rowsToDelete.ForEach(x => dataVeiw.Rows.Remove(x));
            }
        }

        private void OnCreateDirClick(object sender, EventArgs e)
        {
            DataGridView dataVeiw = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiw = leftDataView;
                    break;
                case WindowSide.Right:
                    dataVeiw = rightDataView;
                    break;
            }
            if (dataVeiw != null)
            {
                DirectoryInfo info = dataVeiw.Tag as DirectoryInfo;
                if (info == null)
                {
                    return;
                }
                AskDirectoryNameForm askForm = new AskDirectoryNameForm(prohibitedSymbols);
                if (askForm.ShowDialog() == DialogResult.OK)
                {
                    if (info.FullName.EndsWith("\\"))
                    {
                        //Значит это диск
                        if (Directory.Exists($"{info.FullName}{askForm.Result}"))
                        {
                            MessageBox.Show("Папка с таким названием уже существует!", "Ошибка");
                            return;
                        }
                        DataGridViewRow row = new DataGridViewRow();
                        DirectoryInfo newDirInfo = null;
                        try
                        {
                            newDirInfo = Directory.CreateDirectory($"{info.FullName}{askForm.Result}");
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка создания папки!", "Ошибка");
                            return;
                        }
                        row.Tag = newDirInfo;
                        row.CreateCells(dataVeiw);
                        row.SetValues(new object[6] { DefaultIcons.Folder, newDirInfo.Name, "<DIR>", (long)0, newDirInfo.LastWriteTime.ToString(dateFormat), newDirInfo.Attributes });
                        dataVeiw.Rows.Add(row);
                    }
                    else
                    {
                        //Значит это папка
                        if (Directory.Exists($"{info.FullName}\\{askForm.Result}"))
                        {
                            MessageBox.Show("Папка с таким названием уже существует!", "Ошибка");
                            return;
                        }
                        DataGridViewRow row = new DataGridViewRow();
                        DirectoryInfo newDirInfo = null;
                        try
                        {
                            newDirInfo = Directory.CreateDirectory($"{info.FullName}\\{askForm.Result}");
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка создания папки!", "Ошибка");
                            return;
                        }
                        row.Tag = newDirInfo;
                        row.CreateCells(dataVeiw);
                        row.SetValues(new object[6] { DefaultIcons.Folder, newDirInfo.Name, "<DIR>", (long)0, newDirInfo.LastWriteTime.ToString(dateFormat), newDirInfo.Attributes });
                        dataVeiw.Rows.Add(row);
                    }
                }
            }
        }

        private void OnLowerPanelSizeChanged(object sender, EventArgs e)
        {
            int applyingBtnWidth = lowerPanel.Width / 5;
            for (int i = 0; i < lowerButtons.Length; i++)
            {
                lowerButtons[i].Location = new Point(i * applyingBtnWidth, lowerButtons[i].Location.Y);
                lowerButtons[i].Size = new Size(applyingBtnWidth, lowerButtons[i].Size.Height);
            }
        }
  

     
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            //https://stackoverflow.com/questions/68598/how-do-i-drag-and-drop-files-into-an-application
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            DataGridView dataView = sender as DataGridView;
            if (dataView == null)
            {
                return;
            }
            DirectoryInfo currentDirectory = dataView.Tag as DirectoryInfo;
            if (files != null)
            {
                foreach (string path in files)
                {
                    if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                    {
                        try
                        {
                            CopyDirectory(new DirectoryInfo(path), currentDirectory);
                        }
                        catch
                        {
                            MessageBox.Show($"Путь {path} невозможно скопировать или он был скопирован неполностью");
                            continue;
                        }
                    }
                    else
                    {
                        FileInfo info = new FileInfo(path);
                        try
                        {
                            info.CopyTo($"{currentDirectory.FullName}\\{info.Name}");
                        }
                        catch
                        {
                            MessageBox.Show($"Путь {path} невозможно скопировать или он был скопирован неполностью");
                            continue;
                        }
                    }
                }
                if (files.Length > 0)
                {
                    LoadFilesFromDirectory(currentDirectory, dataView);
                }
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
       

        private void OverWriteDefaultPaths()
        {
            if (readDefaultExecuted)
            {
                DirectoryInfo leftDirInfo = leftDataView.Tag as DirectoryInfo;
                DirectoryInfo rightDirInfo = rightDataView.Tag as DirectoryInfo;
                if (leftDirInfo != null && rightDirInfo != null)
                {
                    File.WriteAllLines("DefaultDirectories.txt", new string[2] { leftDirInfo.FullName, rightDirInfo.FullName });
                }
            }
        }

        private void leftDiskDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox senderBox = sender as ComboBox;
            if (senderBox == null)
            {
                return;
            }
            DriveInfo currentDrive = senderBox.SelectedItem as DriveInfo;
            if (currentDrive == null)
            {
                return;
            }
            switch (senderBox.Name)
            {
                case "leftDiskDropDown":
                   
                    break;
                case "rightDiskDropDown":
                 
                    break;
            }
        }

        private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridView dataView = sender as DataGridView;
            if (dataView == null)
            {
                return;
            }
            DataGridViewRow selectedRow = dataView.Rows[e.RowIndex];
            object rowTag = selectedRow.Tag;
            if (rowTag is DirectoryInfo)
            {
                DirectoryInfo selectedRowInfo = rowTag as DirectoryInfo;
                LoadFilesFromDirectory(selectedRowInfo, dataView);
                //|     Проверка, чтобы лишний раз код не исполнялся
                //V
                if (selectedRowInfo != null && selectedRowInfo.Parent != null && selectedRowInfo.Parent.FullName.Equals(selectedRowInfo.FullName))
                {
                    foreach (DataGridViewRow row in dataView.Rows)
                    {
                        DirectoryInfo rowDirectoryInfo = row.Tag as DirectoryInfo;
                        row.Selected = rowDirectoryInfo != null && rowDirectoryInfo.FullName.Equals(selectedRowInfo.FullName);
                    }
                }
            }
            else
            {
                try
                {
                    Process.Start((rowTag as FileInfo).FullName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Ошибка запуска файла: \n{exception}", "Ошибка запуска");
                }
            }
        }

        private void OnCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataView = sender as DataGridView;
            if (dataView == null)
            {
                return;
            }
            DataGridViewRow selectedRow = dataView.Rows[e.RowIndex];
            object rowTag = selectedRow.Tag;
            if (rowTag == null)
            {
                return;
            }
            string editedText = dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (editedText.Any(x => prohibitedSymbols.Contains(x)))
            {
                MessageBox.Show($"Символы {prohibitedSymbols} нельзя использоватеть в названиях директорий и файлов!", "Ошибка");
                if (rowTag is DirectoryInfo)
                {
                    dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (rowTag as DirectoryInfo).Name;
                }
                else
                {
                    dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (rowTag as FileInfo).Name;
                }
                return;
            }
            if (rowTag is DirectoryInfo)
            {
                DirectoryInfo info = rowTag as DirectoryInfo;
                if (info.Name.Equals(editedText))
                {
                    return;
                }
                if (File.Exists($"{info.Parent.FullName}\\{editedText}"))
                {
                    MessageBox.Show("Такая папка уже существует", "Ошибка");
                    dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = info.Name;
                    return;
                }
                try
                {
                    Directory.Move(info.FullName, $"{info.Parent.FullName}\\{editedText}");
                    dataView.Rows[e.RowIndex].Tag = new DirectoryInfo($"{info.Parent.FullName}\\{editedText}");
                }
                catch
                {
                    MessageBox.Show("Ошибка переименования директории", "Ошибка");
                    dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = info.Name;
                }
            }
            else
            {
                FileInfo info = rowTag as FileInfo;
                string fileNameNoExt = Path.GetFileNameWithoutExtension(info.Name);
                if (fileNameNoExt.Equals(editedText))
                {
                    return;
                }
                if (File.Exists($"{info.Directory.FullName}\\{editedText}{info.Extension}"))
                {
                    MessageBox.Show("Такой файл уже существует", "Ошибка");
                    dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fileNameNoExt;
                    return;
                }
                try
                {
                    File.Move(info.FullName, $"{info.Directory.FullName}\\{editedText}{info.Extension}");
                    dataView.Rows[e.RowIndex].Tag = new FileInfo($"{info.Directory.FullName}\\{editedText}{info.Extension}");
                }
                catch
                {
                    MessageBox.Show("Ошибка переименования директории", "Ошибка");
                    dataView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fileNameNoExt;
                }
            }
        }

        public static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            string newDirectory;
            if (target.FullName.EndsWith("\\"))
            {
                newDirectory = $"{target.FullName}{source.Name}";
            }
            else
            {
                newDirectory = $"{target.FullName}\\{source.Name}";
            }
            Directory.CreateDirectory(newDirectory);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(newDirectory, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void OnSwapBtnClick(object sender, EventArgs e)
        {
            DataGridView dataVeiwSender = null;
            DataGridView dataVeiwReceiver = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiwSender = leftDataView;
                    dataVeiwReceiver = rightDataView;
                    break;
                case WindowSide.Right:
                    dataVeiwSender = rightDataView;
                    dataVeiwReceiver = leftDataView;
                    break;
            }
            if (dataVeiwSender != null && dataVeiwReceiver != null)
            {
                DirectoryInfo senderInfo = dataVeiwSender.Tag as DirectoryInfo;
                DirectoryInfo receiverInfo = dataVeiwReceiver.Tag as DirectoryInfo;
                if (senderInfo != null && receiverInfo != null && !senderInfo.FullName.Equals(receiverInfo.FullName))
                {
                    LoadFilesFromDirectory(senderInfo, dataVeiwReceiver);
                    LoadFilesFromDirectory(receiverInfo, dataVeiwSender);
                }
            }
        }

        private void OnEqualizeBtnClick(object sender, EventArgs e)
        {
            DataGridView dataVeiwSender = null;
            DataGridView dataVeiwReceiver = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiwSender = leftDataView;
                    dataVeiwReceiver = rightDataView;
                    break;
                case WindowSide.Right:
                    dataVeiwSender = rightDataView;
                    dataVeiwReceiver = leftDataView;
                    break;
            }
            if (dataVeiwSender != null && dataVeiwReceiver != null)
            {
                DirectoryInfo senderInfo = dataVeiwSender.Tag as DirectoryInfo;
                DirectoryInfo receiverInfo = dataVeiwReceiver.Tag as DirectoryInfo;
                if (senderInfo != null && receiverInfo != null && !senderInfo.FullName.Equals(receiverInfo.FullName))
                {
                    LoadFilesFromDirectory(senderInfo, dataVeiwReceiver);
                }
            }
        }

        private void OnBackBtnClick(object sender, EventArgs e)
        {
            DataGridView dataVeiw = null;
            switch (side)
            {
                case WindowSide.Left:
                    dataVeiw = leftDataView;
                    break;
                case WindowSide.Right:
                    dataVeiw = rightDataView;
                    break;
            }
            if (dataVeiw != null)
            {
                DirectoryInfo info = dataVeiw.Tag as DirectoryInfo;
                if (info == null || info.Parent == null)
                {
                    return;
                }
                LoadFilesFromDirectory(info.Parent, dataVeiw);
            }
        }

        private void OnExitBtnClick(object sender, EventArgs e) => Close();
    }

    public enum WindowSide
    {
        Left,
        Right
    }
}
