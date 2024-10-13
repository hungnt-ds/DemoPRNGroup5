using System.Windows;

namespace Demo06.ManageProductsApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    ManageProducts products = new ManageProducts();
    private void Window_Loaded(object sender, RoutedEventArgs e) => LoadProducts();

    private void LoadProducts()
    {
        try
        {
            lvProducts.Items.Clear();

            var productList = products.GetProducts(); 

            lvProducts.ItemsSource = productList;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Load Products");
        }
    }

    private void btnInsert_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var Product = new Product
            {
                ProductID = int.Parse(txtProductID.Text),
                ProductName = txtProductName.Text
            };
            products.InsertProduct(Product);
            LoadProducts();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Insert Product");
        }
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var Product = new Product
            {
                ProductID = int.Parse(txtProductID.Text),
                ProductName = txtProductName.Text
            };
            products.UpdateProduct(Product);
            LoadProducts();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Update Product");
        }
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var Product = new Product
            {
                ProductID = int.Parse(txtProductID.Text)
            };
            products.DeleteProduct(Product);
            LoadProducts();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete Product");
        }
    }
}

// D:\Code\ASP.NET\PRN221\DemoPRNGroup5\Demo06.ManageProductsApp\bin\Debug\net8.0-windows