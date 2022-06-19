// See https://aka.ms/new-console-template for more information
Console.WriteLine("Inicio de el juego rol");
Personaje usuario=new Personaje();
Personaje maquina=new Personaje();
maquina.Nombre="Maquina";
maquina.Apodo="CPU";
System.Console.WriteLine("Dame el nombre de tu personaje");
usuario.Nombre=Console.ReadLine();
Random aux= new Random();
usuario.Apodo=usuario.Nombre.Substring(aux.Next(1,3));
System.Console.WriteLine("De que tipo va a ser tu personaje? ");
System.Console.WriteLine("1-valquiria,2-caballero,3-ogro,4-mago,5-bruja");
int auxNumeros=Int32.Parse(Console.ReadLine());
switch (auxNumeros)
{
    case 1:
        usuario.tipoDos=Tipos.valquiria;
        break;
    case 2:
        usuario.tipoDos=Tipos.caballero;
        break;
    case 3:
        usuario.tipoDos=Tipos.ogro;
        break;
    case 4:
        usuario.tipoDos=Tipos.mago;
        break;
    default:
        usuario.tipoDos=Tipos.bruja;
        break;
}
Random auxTipos=new Random();
Tipos nose;
switch (auxTipos.Next(1,5))
{
    case 1:
        maquina.tipoDos=Tipos.valquiria;
        break;
    case 2:
        maquina.tipoDos=Tipos.caballero;
        break;
    case 3:
        maquina.tipoDos=Tipos.ogro;
        break;
    case 4:
        maquina.tipoDos=Tipos.mago;
        break;
    default:
        maquina.tipoDos=Tipos.bruja;
        break;
}
System.Console.WriteLine("Fecha de nacimiento");
System.Console.WriteLine("Año en el que naciste: ");
int anio=Int32.Parse(Console.ReadLine());
System.Console.WriteLine("Mes en el que naciste");
int mes=Int32.Parse(Console.ReadLine());
System.Console.WriteLine("Dia en el que naciste");
int dia=Int32.Parse(Console.ReadLine());
usuario.FechaNacimiento=new DateTime(anio,mes,dia);
maquina.FechaNacimiento=new DateTime(anio,mes,dia);
usuario.aleatorios();
usuario.valores();
maquina.aleatorios();
maquina.valores();
//muestro por pantalla los valores adquiridos por ambos personajes
System.Console.WriteLine("Los valores adquiridos por la CPU a los cuales te vas a enfrentar son:");
System.Console.WriteLine("Armadura: "+ maquina.Armadura);
System.Console.WriteLine("Fuerza: "+maquina.Fuerza);
System.Console.WriteLine("Destreza: "+maquina.Velocidad);
System.Console.WriteLine("Nivel: "+maquina.Nivel);
System.Console.WriteLine("Salud: "+maquina.Salud);
System.Console.WriteLine("Edad: "+maquina.Edad);
System.Console.WriteLine("Tipo: "+maquina.tipoDos);
System.Console.WriteLine("Los datos de tu personaje son: ");
System.Console.WriteLine("Armadura: "+ usuario.Armadura);
System.Console.WriteLine("Fuerza: "+usuario.Fuerza);
System.Console.WriteLine("Destreza: "+usuario.Velocidad);
System.Console.WriteLine("Nivel: "+usuario.Nivel);
System.Console.WriteLine("Salud: "+usuario.Salud);
System.Console.WriteLine("Edad: "+usuario.Edad);
System.Console.WriteLine("Tipo: "+usuario.tipoDos);
System.Console.WriteLine("Nombre: "+usuario.Nombre);
System.Console.WriteLine("Apodo: "+usuario.Apodo);
//comienzo del juego:
int aux=2;
while (aux>1)
{
    System.Console.WriteLine("El juego esta por comenzar presiona 1 para empezar");
    aux=INT32.Parse(Console.ReadLine());   
}

while (usuario.Salud>0 && maquina.Salud>0) // mientras ambos tengan salud masyor a 0
{
        
}

//inico de las clases

class caracteristicas
{
    private int velocidad;
    private Random aux=new Random();
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
        this.armadura=aux.Next(1,10);
        this.velocidad=aux.Next(1,10);
        this.destreza=aux.Next(1,5);
        this.fuerza=aux.Next(1,10);
        this.nivel=aux.Next(1,10);
    }
}
enum Tipos
{
    valquiria,
    caballero,
    ogro,
    mago,
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
    private Random aux=new Random();
    public void aleatorios(){
        this.edad=aux.Next(0,300);
        this.salud=100;
    }
}