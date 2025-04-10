namespace TP_1_P_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tipoFactura = 0;

            //se solicita el tipo de factura
            Console.WriteLine("Seleccione el tipo de factura que desea emitir: ");
            Console.WriteLine("\n1 - Responsable inscripto.");
            Console.WriteLine("2 - Consumidor final.");
            Console.WriteLine("3 - Bienes y servicios.");
            tipoFactura = int.Parse(Console.ReadLine()); //se guarda la opción elegida

            //se solicita la cantidad de ítems que se desea ingresar
            Console.WriteLine("¿Cuántos ítems desea ingresar?");
            int cantidadItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidadItems; i++) //bucle que se repite por cada ítem
            {
                Item item = new Item(); //se crea un nuevo ítem

                Console.WriteLine($"\nIngrese el nombre del artículo {i + 1}:");
                item.Articulo = Console.ReadLine(); //se asigna el nombre

                Console.WriteLine("Ingrese el precio unitario:");
                item.Precio = double.Parse(Console.ReadLine()); //se asigna el precio

                Console.WriteLine("Ingrese la cantidad:");
                item.Cantidad = double.Parse(Console.ReadLine()); //se asigna la cantidad

                double importeBruto = item.ImporteItem(); //se calcula el importe bruto (precio * cantidad)

                double importeFinal = 0;

                //Se aplica el ajuste según el tipo de factura
                if (tipoFactura == 1)
                    importeFinal = importeBruto * 1.105; //10,5% adicional
                else if (tipoFactura == 2)
                    importeFinal = importeBruto * 1.21; //21% adicional
                else if (tipoFactura == 3)
                    importeFinal = importeBruto * 0.73; //27% de descuento

                Item.Items.Add(item); //se agrega el ítem a la lista

                //Se muestra el resumen del ítem
                Console.WriteLine("\n----- Resumen del ítem -----");
                Console.WriteLine("Artículo: " + item.Articulo);
                Console.WriteLine("Precio unitario: " + item.Precio);
                Console.WriteLine("Cantidad: " + item.Cantidad);
                Console.WriteLine("Importe bruto: " + importeBruto);
                Console.WriteLine("Importe final (ajustado): " + importeFinal);
            }

            ItemMayorValor(); //se llama al método que busca el ítem de mayor valor
            CalcularPromedioImporte(); //se llama al método que calcula el promedio
        }

        static void ItemMayorValor()
        {
            double mayorImporte = 0; //variable para guardar el mayor importe
            Item itemMayor = null; //variable para guardar el ítem con mayor valor

            foreach (Item item in Item.Items) //se recorre la lista de ítems
            {
                double importe = item.ImporteItem(); //se calcula el importe del ítem

                if (importe > mayorImporte) //si es mayor al mayor actual
                {
                    mayorImporte = importe; //se guarda el nuevo mayor importe
                    itemMayor = item; //se guarda el ítem correspondiente
                }
            }

            if (itemMayor != null) //si se encontró un ítem con mayor valor
            {
                Console.WriteLine("\n--- Ítem de mayor valor ---");
                Console.WriteLine("Artículo: " + itemMayor.Articulo);
                Console.WriteLine("Precio: " + itemMayor.Precio);
                Console.WriteLine("Cantidad: " + itemMayor.Cantidad);
                Console.WriteLine("Importe: " + mayorImporte);
            }
        }

        static void CalcularPromedioImporte()
        {
            double sumaImportes = 0; //acumulador para los importes

            foreach (Item item in Item.Items) //se recorre cada ítem
            {
                sumaImportes += item.ImporteItem(); //se suma el importe de cada uno
            }

            int cantidadItems = Item.Items.Count; //se obtiene la cantidad total de ítems

            if (cantidadItems > 0) //si hay 1 o mas cantidad de items se muestra lo siguiente
            {
                double promedio = sumaImportes / cantidadItems; //se calcula el promedio
                Console.WriteLine("\n--- Promedio de importes ---");
                Console.WriteLine("Promedio: " + promedio);
            }
            else
            {
                Console.WriteLine("\nNo hay ítems para calcular el promedio.");
            }
        }
    }
}