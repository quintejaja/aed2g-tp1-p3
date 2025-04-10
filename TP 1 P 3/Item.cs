using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1_P_3
{
    public class Item
    {
        private static List<Item> items = new List<Item>();
        private string articulo;
        private double precio;
        private double cantidad;

        public static List<Item> Items { get => items; set => items = value; }
        public string Articulo { get => articulo; set => articulo = value; }
        public double Precio { get => precio; set => precio = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }

        public Item(string articulo, int precio, int cantidad) 
        {
            this.articulo = articulo;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public Item() 
        {
            articulo = string.Empty;
            precio = 0;
            cantidad = 0;
        }
        
        public double ImporteItem() 
        {
            return this.cantidad * this.precio;
        }
    }
}