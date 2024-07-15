// See https://aka.ms/new-console-template for more information
using System;

public class Program
{
    public static void Main()
    {
      
        Cafetera cafetera = new Cafetera(50);
        Vaso vasosPequeno = new Vaso(5, 10);
        Vaso vasosMediano = new Vaso(5, 20);
        Vaso vasosGrande = new Vaso(5, 30);
        Azucarero azucarero = new Azucarero(20);

    
        MaquinaDeCafe maquinaDeCafe = new MaquinaDeCafe();
        maquinaDeCafe.setCafetera(cafetera);
        maquinaDeCafe.setVasosPequeno(vasosPequeno);
        maquinaDeCafe.setVasosMediano(vasosMediano);
        maquinaDeCafe.setVasosGrande(vasosGrande);
        maquinaDeCafe.setAzucarero(azucarero);

        
        while (true)
        {
            Console.WriteLine("Seleccione el tipo de vaso: ");
            Console.WriteLine("1. Pequeño");
            Console.WriteLine("2. Mediano");
            Console.WriteLine("3. Grande");
            string opcionVaso = Console.ReadLine();
            Vaso vasoSeleccionado = null;

            switch (opcionVaso)
            {
                case "1":
                    vasoSeleccionado = maquinaDeCafe.getTipoVaso("pequeno");
                    break;
                case "2":
                    vasoSeleccionado = maquinaDeCafe.getTipoVaso("mediano");
                    break;
                case "3":
                    vasoSeleccionado = maquinaDeCafe.getTipoVaso("grande");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    continue;
            }

            Console.WriteLine("Ingrese la cantidad de café: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadCafe))
            {
                Console.WriteLine("Cantidad de café no válida. Intente nuevamente.");
                continue;
            }

            Console.WriteLine("Ingrese la cantidad de azúcar: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadAzucar))
            {
                Console.WriteLine("Cantidad de azúcar no válida. Intente nuevamente.");
                continue;
            }

            string resultado = maquinaDeCafe.getVasoDeCafe(vasoSeleccionado, 1, cantidadCafe);
            Console.WriteLine(resultado);

           
            Console.WriteLine("Café restante en la cafetera: " + cafetera.getCantidadCafe());
            Console.WriteLine("Azúcar restante en el azucarero: " + azucarero.getCantidadAzucar());
            Console.WriteLine("Vasos pequeños restantes: " + vasosPequeno.getCantidadVasos());
            Console.WriteLine("Vasos medianos restantes: " + vasosMediano.getCantidadVasos());
            Console.WriteLine("Vasos grandes restantes: " + vasosGrande.getCantidadVasos());

            Console.WriteLine("¿Desea solicitar otro vaso de café? (si/no): ");
            string continuar = Console.ReadLine();
            if (continuar.ToLower() != "si")
            {
                break;
            }
        }
    }
}

public class Vaso
{
    private int cantidadVasos;
    private int contenido;

    public Vaso(int cantidadVasos, int contenido)
    {
        this.cantidadVasos = cantidadVasos;
        this.contenido = contenido;
    }

    public void setCantidadVasos(int cantidad)
    {
        this.cantidadVasos = cantidad;
    }

    public int getCantidadVasos()
    {
        return this.cantidadVasos;
    }

    public void giveVasos(int cantidad)
    {
        this.cantidadVasos -= cantidad;
    }

    public int getContenido()
    {
        return this.contenido;
    }
}

public class Cafetera
{
    private int cantidadCafe;

    public Cafetera(int cantidadCafe)
    {
        this.cantidadCafe = cantidadCafe;
    }

    public bool hasCafe(int cantidad)
    {
        return this.cantidadCafe >= cantidad;
    }

    public void giveCafe(int cantidad)
    {
        this.cantidadCafe -= cantidad;
    }

    public int getCantidadCafe()
    {
        return this.cantidadCafe;
    }
}

public class Azucarero
{
    private int cantidadAzucar;

    public Azucarero(int cantidadAzucar)
    {
        this.cantidadAzucar = cantidadAzucar;
    }

    public bool hasAzucar(int cantidad)
    {
        return this.cantidadAzucar >= cantidad;
    }

    public void giveAzucar(int cantidad)
    {
        this.cantidadAzucar -= cantidad;
    }

    public int getCantidadAzucar()
    {
        return this.cantidadAzucar;
    }
}

public class MaquinaDeCafe
{
    private Cafetera cafetera;
    private Vaso vasosPequeno;
    private Vaso vasosMediano;
    private Vaso vasosGrande;
    private Azucarero azucarero;

    public MaquinaDeCafe()
    {
    }

    public void setVasosPequeno(Vaso vaso)
    {
        this.vasosPequeno = vaso;
    }

    public void setVasosMediano(Vaso vaso)
    {
        this.vasosMediano = vaso;
    }

    public void setVasosGrande(Vaso vaso)
    {
        this.vasosGrande = vaso;
    }

    public void setCafetera(Cafetera cafetera)
    {
        this.cafetera = cafetera;
    }

    public void setAzucarero(Azucarero azucarero)
    {
        this.azucarero = azucarero;
    }

    public Vaso getTipoVaso(string tipoDeVaso)
    {
        return tipoDeVaso.ToLower() switch
        {
            "pequeno" => this.vasosPequeno,
            "mediano" => this.vasosMediano,
            "grande" => this.vasosGrande,
            _ => null
        };
    }

    public string getVasoDeCafe(Vaso vaso, int cantidadDeVasos, int cantidadDeCafe)
    {
        if (vaso == null)
        {
            return "Tipo de vaso no válido";
        }

        if (vaso.getCantidadVasos() >= cantidadDeVasos && this.cafetera.hasCafe(cantidadDeCafe) && this.azucarero.hasAzucar(cantidadDeCafe))
        {
            this.cafetera.giveCafe(cantidadDeCafe);
            vaso.giveVasos(cantidadDeVasos);
            this.azucarero.giveAzucar(cantidadDeCafe);
            return "Felicitaciones";
        }
        else
        {
            if (vaso.getCantidadVasos() < cantidadDeVasos)
                return "No hay Vasos";
            else if (!this.cafetera.hasCafe(cantidadDeCafe))
                return "No hay Cafe";
            else
                return "No hay Azucar";
        }
    }
}

