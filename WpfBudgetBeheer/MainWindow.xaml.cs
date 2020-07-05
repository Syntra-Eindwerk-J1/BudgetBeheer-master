using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfBudgetBeheer.ViewModel;


namespace WpfBudgetBeheer
{

	public partial class MainWindow : Window
	{
		trViewM _viewmod = null;
		public trViewM ViewMod
		{
			get { _viewmod ??= new trViewM(); return _viewmod; }
			set => _viewmod = value;
		}
		public MainWindow()
		{
			InitializeComponent();
			ViewMod.Import();
			DataContext = ViewMod;
		}

		private void FontSizeEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !IsNumber(e.Text);
		}
		public bool IsNumber(string txt) => int.TryParse(txt, out int i);

		private void ImportButton_Click(object sender, RoutedEventArgs e)
		{
			/*OpenFileDialog openDlg = new OpenFileDialog()
			{
				Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"
			};
			if (openDlg.ShowDialog() == true)
			{
			CatViewModel.ImportFromFile(openDlg.FileName);
			TrViewModel.ImportFromFile(openDlg.FileName);
			}*/


		}

		private void ExportButton_Click(object sender, RoutedEventArgs e)
		{

			ViewMod.SaveAllData();
		}


		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void AddHCButton_Click(object sender, RoutedEventArgs e)
		{
			//var now = DateTime.Now.Date;
			ViewMod.NieuwTrDatum = new DateTime();
			ViewMod.NieuwTrDatum = (DateTime)TrDatum.SelectedDate;
			ViewMod.NieuwTrOmschrijving = TrOmschrijving.Text;
			double deb; double cred;
			double.TryParse(TrDebet.Text, out deb);
			double.TryParse(TrCredit.Text, out cred);
			ViewMod.NieuwTrDebet = deb;
			ViewMod.NieuwTrCredit = cred;
			if (ViewMod.NieuwTrHoofdCat != null && ViewMod.NieuwTrSubCat != null && (ViewMod.NieuwTrDebet > 0 || ViewMod.NieuwTrCredit > 0))
			{
				ViewMod.addTransactiePost(ViewMod.NieuwTrDatum, ViewMod.NieuwTrHoofdCat, ViewMod.NieuwTrSubCat, ViewMod.NieuwTrOmschrijving, ViewMod.NieuwTrDebet, ViewMod.NieuwTrCredit);
			}
			//ViewMod.NieuwTrHoofdCat = null
			ViewMod.NieuwTrHoofdCat = null;
			ViewMod.NieuwTrSubCat = null;


			TrDatum.SelectedDate = DateTime.Now;
			TrOmschrijving.Text = null;
			TrDebet.Text = null;
			TrCredit.Text = null;
			ComboHoofdCat.SetBinding(
			System.Windows.Controls.Primitives.Selector.SelectedItemProperty,
			new Binding("SelectedItem") { Source = ViewMod, Path = new PropertyPath("CurrentTP.HoofdCat"), Mode = BindingMode.OneTime, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });

		}



		private void DeleteTransactieButton_Click(object sender, RoutedEventArgs e)
		{

			ViewMod.deleteTransactiePost(ViewMod.CurrentTP);
			TransactieGrid.Items.Refresh();

		}


		private void EditTransactieButton_Click(object sender, RoutedEventArgs e)
		{



			if (ViewMod.CurrentTP != null)
			{

				ComboHoofdCat.SetBinding(
				ItemsControl.ItemsSourceProperty,
				new Binding { Source = ViewMod, Path = new PropertyPath("HCCollectie") });

				ComboHoofdCat.SetBinding(
				System.Windows.Controls.Primitives.Selector.SelectedItemProperty,
				new Binding("SelectedItem") { Source = ViewMod, Path = new PropertyPath("CurrentTP.HoofdCat"), Mode = BindingMode.OneWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });




				ComboSubCat.SetBinding(
				ItemsControl.ItemsSourceProperty,
				new Binding { Source = ViewMod, Path = new PropertyPath("CurrSCCollectie"), Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

				ComboSubCat.SetBinding(
				System.Windows.Controls.Primitives.Selector.SelectedItemProperty,
				new Binding("SelectedItem") { Source = ViewMod, Path = new PropertyPath("CurrentTP.SubCat"), Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });

			}



		}

		private void Row_MouseUp(object sender, MouseButtonEventArgs e)
		{

		}

		private void Row_MouseDown(object sender, MouseButtonEventArgs e)
		{
			ViewMod.UpdateGui();
			/*if (ViewMod.CurrentTP != null)
			{
				if (ViewMod.CurrSubCatLijstNaam.Count == 0)
				{
					if(ViewMod.CurrSubCatLijstNaam.Count != 0)
					{

					}
				}
			}
			//return ViewMod.CurrSubCatLijstNaam != null;
			if (ViewMod.CurrSubCatLijstNaam.Count == 0)
			{

			}*/
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{


		}

		private void NieuweTransactieButton_Click(object sender, RoutedEventArgs e)
		{
			/*TrID.SetBinding(
			ItemsControl.ItemsSourceProperty,
			*/
			ViewMod.CurrentTP = null;
			ComboHoofdCat.SetBinding(
			ItemsControl.ItemsSourceProperty,
			new Binding { Source = ViewMod, Path = new PropertyPath("HCCollectie"), Mode = BindingMode.OneTime, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

			ComboHoofdCat.SetBinding(
			System.Windows.Controls.Primitives.Selector.SelectedItemProperty,
			new Binding("SelectedItem") { Source = ViewMod, Path = new PropertyPath("NieuwTrHoofdCat"), Mode = BindingMode.OneTime, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });


			ComboSubCat.SetBinding(
			ItemsControl.ItemsSourceProperty,
			new Binding { Source = ViewMod, Path = new PropertyPath("CurrSCCollectie"), Mode = BindingMode.OneTime, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

			ComboSubCat.SetBinding(
			System.Windows.Controls.Primitives.Selector.SelectedItemProperty,
			new Binding("SelectedItem") { Source = ViewMod, Path = new PropertyPath("NieuwTrSubCat"), Mode = BindingMode.OneWayToSource, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });

			TrDatum.SetBinding(
			ItemsControl.ItemsSourceProperty,
			new Binding { Source = ViewMod, Path = new PropertyPath("NieuwTrDatum"), Mode = BindingMode.OneWayToSource, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

			TrDatum.SetBinding(
			System.Windows.Controls.Primitives.Selector.SelectedItemProperty,
			new Binding("SelectedDatum") { Source = ViewMod, Path = new PropertyPath("NieuwTrDatum"), Mode = BindingMode.OneTime, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });

			TrOmschrijving.SetBinding(
			ItemsControl.ItemsSourceProperty,
			new Binding { Source = ViewMod, Path = new PropertyPath("NieuwTrOmschrijving"), Mode = BindingMode.OneTime, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });

			TrDebet.SetBinding(
			ItemsControl.ItemsSourceProperty,
			new Binding { Source = ViewMod, Path = new PropertyPath("NieuwTrDebet"), UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

			TrCredit.SetBinding(
			ItemsControl.ItemsSourceProperty,
			new Binding { Source = ViewMod, Path = new PropertyPath("NieuwTrCredit"), Mode = BindingMode.OneTime, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus });


		}

		private void ButtonOpslaan_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ButtonLeegmaken_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ButtonStop_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BtnCredit_Checked(object sender, RoutedEventArgs e)
		{
		}
	}
}

