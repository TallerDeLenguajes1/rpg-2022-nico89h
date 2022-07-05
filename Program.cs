List<Personaje> grupo1= new List<Personaje>();
//incio el guardado de los datos en las listas
Personaje grupo= new Personaje();
for (int i = 0; i < 4; i++)
{
    grupo=cargarDatos();
    grupo1.Insert(i,new Personaje{Nombre=grupo.Nombre,Apodo=grupo.Apodo,FechaNacimiento=grupo.FechaNacimiento});
    grupo1[i].aleatorios();
    grupo1[i].valores();
}
List<Personaje> grupo2= new List<Personaje>();
//int m=0;
for (int e = 0; e < 4; e++)
{
    grupo=cargarDatos();
    grupo2.Insert(e,new Personaje{Nombre=grupo.Nombre,Apodo=grupo.Apodo,FechaNacimiento=grupo.FechaNacimiento});
    grupo2[e].aleatorios();
    grupo2[e].valores();
}
//fin de el guardado de datos

//inicio con el combate de los jugadores
Random indice1=new Random();
Random indice2=new Random();
List<Personaje> Resultados= new List<Personaje>();
List<bool> controles= new List<bool>();
controles=control(8); // comienzo de todos los jugadores
for (int i = 0; i < 4; i++) // son en total 4
{

}





//inicio de funciones
//inicializo la lista en true, donde va a representar lo que es los indices de los personajes
List<bool> control(int cantidad){
    List<bool> aux=new List<bool>();
    for (int i = 0; i < cantidad; i++)
    {
        aux.Insert(i, true);
    }
    return aux;
}

Personaje cargarDatos(){
    Random auxTipos=new Random();
    var random = new Random();
    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    var Charsarr = new char[5];
    Personaje grupo=new Personaje();
    for (int f = 0; f < Charsarr.Length; f++)
    {
        Charsarr[f] = characters[random.Next(characters.Length)];
    }
    grupo.Nombre=new String(Charsarr);
    grupo.Apodo= grupo.Nombre.Substring(auxTipos.Next(1,3));
    grupo.aleatorios();
    grupo.valores();
    switch (auxTipos.Next(1,6))
    {
        case 1:
            grupo.tipoDos=Tipos.valquiria;
            break;
        case 2:
            grupo.tipoDos=Tipos.caballero;
            break;
        case 3:
            grupo.tipoDos=Tipos.ogro;
            break;
        case 4:
            grupo.tipoDos=Tipos.mago;
            break;
        default:
            grupo.tipoDos=Tipos.bruja;
            break;
    }
    grupo.FechaNacimiento=new DateTime(auxTipos.Next(1900,2023),auxTipos.Next(1,13),auxTipos.Next(1,26));
    return grupo;
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
class Personaje:caracteristicas// con esto indicamos que el personaje tiene las caractersiaticas ya mencionadas
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
