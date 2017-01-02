using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using MyKeyenceLib;

namespace VK4_2_MAT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Uri myuri;
        BitmapImage imgdis ;
        
        public MainWindow()
        {
            myuri = new Uri("pack://application:,,,/dis.png");
            imgdis = new BitmapImage(myuri);

            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "Select VK4 Files...";
            dialog.Filter = "VK4 Files|*.vk4";
            if (dialog.ShowDialog(this) == true)
            {
                foreach  (string path in dialog.FileNames)
                {
                    lstFileList.Items.Add(path);
                }
                
            }
            if (lstFileList.Items.Count != 0)
            {
                btnExport.IsEnabled = true;
            }
            else
            {
                btnExport.IsEnabled = false;
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            object[] itemsToRemove = new object[lstFileList.SelectedItems.Count];
            lstFileList.SelectedItems.CopyTo(itemsToRemove, 0);
            foreach (object item in itemsToRemove)
            {
                lstFileList.Items.Remove(item);
            }
            if (lstFileList.Items.Count != 0)
            {
                btnExport.IsEnabled = true;
            }
            else
            {
                btnExport.IsEnabled = false;
            }

        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();

            System.Windows.Forms.DialogResult result = fbd.ShowDialog();
            if (result== System.Windows.Forms.DialogResult.OK)
            {
                fileTxt.Text = fbd.SelectedPath;
            }
           

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            VK4IO.MatExportInclude.Color_Peak = chkColor_Peak.IsChecked.Value;
            VK4IO.MatExportInclude.Color_Light = chkColor_Light.IsChecked.Value;
            VK4IO.MatExportInclude.Height_Data = chkHeight.IsChecked.Value;
            VK4IO.MatExportInclude.Inc_Palette = chkInc_pal.IsChecked.Value;
            VK4IO.MatExportInclude.Light_Data = chkLaser.IsChecked.Value;
            VK4IO.MatExportInclude.Meas_Cond = chkMeas_Cond.IsChecked.Value;
            Pbar.Value = 0;
            mainGRID.IsEnabled = false;
            for (int i = 0; i < lstFileList.Items.Count; i++)
            {
                VK4_DataFile VK4Dat = VK4IO.LoadVK4File((string)lstFileList.Items[i]);
                string MatPath;
                if (chkSaveToNewLoc.IsChecked.Value)
                {
                    MatPath = String.Concat(Path.GetDirectoryName(fileTxt.Text + "\\"), "\\", Path.GetFileNameWithoutExtension((string)lstFileList.Items[i]), ".mat");
                }
                else
                {
                    
                    MatPath = String.Concat(Path.GetDirectoryName((string)lstFileList.Items[i]), "\\", Path.GetFileNameWithoutExtension((string)lstFileList.Items[i]), ".mat");
                }
                if (chkAddTime.IsChecked.Value)
                {
                    MatPath = String.Concat(Path.GetDirectoryName(MatPath), "\\", Path.GetFileNameWithoutExtension(MatPath),"_", DateTime.Now.ToString("yyyyMMddHHmmss"),".mat");
                }
                VK4IO.WriteMatFile(MatPath, VK4Dat);
                Pbar.Value = ((i + 1) * 100) / lstFileList.Items.Count;
                Pbar.Dispatcher.Invoke(() => Pbar.Value = ((i + 1) * 100) / lstFileList.Items.Count, System.Windows.Threading.DispatcherPriority.Background);
                
                
            }
            mainGRID.IsEnabled = true;
            Pbar.Value = 0;
        }

        public BitmapSource imageSource, imageSource2;

        private void lstFileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            imageSource = imageSource2 = null;
            if (chkprev.IsChecked.Value && (string)lstFileList.SelectedItem != null)
            {             
                VK4_DataFile VK4Dat = VK4IO.LoadVK4File((string)lstFileList.SelectedItem);

                int width = (int)VK4Dat.LASERCOLOR_THUMB.width, height = (int)VK4Dat.LASERCOLOR_THUMB.height, bytesperpixel = (int)VK4Dat.LASERCOLOR_THUMB.bit_depth / 8;
                int stride = width * bytesperpixel;
                imageSource = BitmapSource.Create(width, height, 96, 96, PixelFormats.Rgb24, null, VK4Dat.LASERCOLOR_THUMB.data, stride);

                width = (int)VK4Dat.HEIGHT_THUMB.width; height = (int)VK4Dat.HEIGHT_THUMB.height; bytesperpixel = (int)VK4Dat.HEIGHT_THUMB.bit_depth / 8;
                stride = width * bytesperpixel;
                imageSource2 = BitmapSource.Create(width, height, 96, 96, PixelFormats.Rgb24, null, VK4Dat.HEIGHT_THUMB.data, stride);
            }
            updatePrev();

        }


        private void chkprev_Click(object sender, RoutedEventArgs e)
        {
            updatePrev();
        }
        private void updatePrev()
        {

            if (chkprev.IsChecked.Value && imageSource != null && imageSource2 != null)
            {
                imgPrev1.Source = imageSource;
                imgPrev2.Source = imageSource2;
            }
            else
            {
                
                imgPrev1.Source = imgdis;
                imgPrev2.Source = imgdis;
            }
        }
    }
}
