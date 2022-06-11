// See https://aka.ms/new-console-template for more information
Console.WriteLine("Inicio de el juego rol");
Personaje personaje;
System.Console.WriteLine("Dame el nombre de tu personaje");
personaje.Nombre=Console.ReadLine();
System.Console.WriteLine(personaje.Nombre);
//inico de las clases

class caracteristicas
{
    private int velocidad;
    private Random aux;
    public int Velocidad{
        get{
            return velocidad;
        }
    }
    private int destreza;
    public int Destreza{
        get{
            return destreza;
        }
    }
    private int fuerza;
    public int Fuerza{
        get{
            return fuerza;
        }
    }
    private int nivel;
    public int Nivel{
        get{
            return nivel;
        }
    }
    private int armadura;
    public int Armadura{
        get{
            return armadura;
        }
    }
    public void valores(){
        armadura=aux.Next(1,10);
        velocidad=aux.Next(1,10);
        destreza=aux.Next(1,5);
        fuerza=aux.Next(1,10);
        nivel=aux.Next(1,10);
    }
}
enum Tipos
{
    valquiria,
    caballero,
    ogro,
    brujo,
    bruja
}
class Personaje:caracteristicas // con esto indicamos que el personaje tiene las caractersiaticas ya mencionadas
{
    private Tipos tipo;
    public Tipos tipoDos{
        get{
            return tipo;
        }
        set{
            tipo=value;
        }
    }
    private string nombre;
    public string Nombre{
        get{
            return nombre;
        }
        set{
            nombre=value;
        }
    }
    private string apodo;
    public string Apodo{
        get{
            return apodo;
        }
        set{
            apodo=value;
        }
    }
    private DateTime fechaNacimiento;
    public DateTime FechaNacimiento{
        get{
            return fechaNacimiento;
        }
        set{
            fechaNacimiento=value;
        }
    }
    private int edad;
    public int Edad{
        get{
            return edad;
        }
    }
    private int salud;
    public int Salud{
        get{
            return salud;
        }
    }
    private Random aux;
    public void aleatorios(){
        edad=aux.Next(0,300);
        salud=100;
    }
}