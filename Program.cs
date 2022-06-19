Personaje [] grupo1= new Personaje[5];
Random auxTipos=new Random();
var random = new Random();
var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
var Charsarr = new char[5];
for (int i = 0; i < 5; i++)
{
    grupo1[i]=new Personaje();
    for (int f = 0; f < Charsarr.Length; f++)
    {
        Charsarr[f] = characters[random.Next(characters.Length)];
    }
    grupo1[i].Nombre=new String(Charsarr);
    grupo1[i].Apodo= grupo1[i].Nombre.Substring(auxTipos.Next(1,3));
    grupo1[i].aleatorios();
    grupo1[i].valores();
    switch (auxTipos.Next(1,6))
    {
        case 1:
            grupo1[i].tipoDos=Tipos.valquiria;
            break;
        case 2:
            grupo1[i].tipoDos=Tipos.caballero;
            break;
        case 3:
            grupo1[i].tipoDos=Tipos.ogro;
            break;
        case 4:
            grupo1[i].tipoDos=Tipos.mago;
            break;
        default:
            grupo1[i].tipoDos=Tipos.bruja;
            break;
    }
    grupo1[i].FechaNacimiento=new DateTime(auxTipos.Next(1900,2023),auxTipos.Next(1,13),auxTipos.Next(1,26));
}
Personaje [] grupo2= new Personaje[5];
int m=0;
var ola = new Random();
var jose = new char[5];
for (int e = 0; e < 4; e++)
{
    grupo2[e]=new Personaje();
    for (int r = 0; r < jose.Length; r++)
    {
        jose[r] = characters[ola.Next(characters.Length)];
    }
    grupo2[e].Nombre=new String(jose);
    grupo2[e].Apodo= grupo2[e].Nombre.Substring(auxTipos.Next(1,3));
    grupo2[e].aleatorios();
    grupo2[e].valores();
    switch (auxTipos.Next(1,6))
    {
        case 1:
            grupo2[e].tipoDos=Tipos.valquiria;
            break;
        case 2:
            grupo2[e].tipoDos=Tipos.caballero;
            break;
        case 3:
            grupo2[e].tipoDos=Tipos.ogro;
            break;
        case 4:
            grupo2[e].tipoDos=Tipos.mago;
            break;
        default:
            grupo2[e].tipoDos=Tipos.bruja;
            break;
    }
    grupo2[e].FechaNacimiento=new DateTime(auxTipos.Next(1900,2023),auxTipos.Next(1,13),auxTipos.Next(1,26));
    //m++;
}
m=4;
grupo2[m]=new Personaje();
System.Console.WriteLine("Dame el nombre de tu personaje");
grupo2[m].Nombre=Console.ReadLine();
Random aux= new Random();
grupo2[m].Apodo=grupo2[m].Nombre.Substring(aux.Next(1,3));
System.Console.WriteLine("De que tipo va a ser tu personaje? ");
System.Console.WriteLine("1-valquiria,2-caballero,3-ogro,4-mago,5-bruja");
int auxNumeros=Int32.Parse(Console.ReadLine());
switch (auxNumeros)
{
    case 1:
        grupo2[m].tipoDos=Tipos.valquiria;
        break;
    case 2:
        grupo2[m].tipoDos=Tipos.caballero;
        break;
    case 3:
        grupo2[m].tipoDos=Tipos.ogro;
        break;
    case 4:
        grupo2[m].tipoDos=Tipos.mago;
        break;
    default:
        grupo2[m].tipoDos=Tipos.bruja;
        break;
}

System.Console.WriteLine("Fecha de nacimiento");
System.Console.WriteLine("Año en el que naciste: ");
int anio=Int32.Parse(Console.ReadLine());
System.Console.WriteLine("Mes en el que naciste");
int mes=Int32.Parse(Console.ReadLine());
System.Console.WriteLine("Dia en el que naciste");
int dia=Int32.Parse(Console.ReadLine());
grupo2[m].FechaNacimiento=new DateTime(anio,mes,dia);
grupo2[m].aleatorios();
grupo2[m].valores();
//muestro por pantalla los valores adquiridos por el usuario
System.Console.WriteLine("Los datos de tu personaje son: ");
System.Console.WriteLine("Armadura: "+ grupo2[m].Armadura);
System.Console.WriteLine("Fuerza: "+grupo2[m].Fuerza);
System.Console.WriteLine("Destreza: "+grupo2[m].Velocidad);
System.Console.WriteLine("Nivel: "+grupo2[m].Nivel);
System.Console.WriteLine("Salud: "+grupo2[m].Salud);
System.Console.WriteLine("Edad: "+grupo2[m].Edad);
System.Console.WriteLine("Tipo: "+grupo2[m].tipoDos);
System.Console.WriteLine("Nombre: "+grupo2[m].Nombre);
System.Console.WriteLine("Apodo: "+grupo2[m].Apodo);
//comienzo del juego:
Random buenas=new Random();
int [] indicesGrupo1= new int[5];
int [] indicesGrupo2= new int[5];
int auxdos;
int control=1;
int ataqueSiguiente;
// for (int k = 5; k < 10; k++)
// {
//     jugadores[k]=new Personaje();
//     jugadores[k]=grupo2[k];
// }
for (int t = 0; t < 5; t++)
{
    auxdos=buenas.Next(1,6);
    if (t==0)
    {
        indicesGrupo1[t]=auxdos;
        indicesGrupo2[t]=auxdos;
    }else
    {
        //indice grupo uno
        if (Array.Exists(indicesGrupo1,x=>x==auxdos))
        {
            auxdos=buenas.Next(1,6);
            while (Array.Exists(indicesGrupo1,x=>x==auxdos))
            {
                auxdos=buenas.Next(1,6);
            }
            indicesGrupo1[t]=auxdos;
        }else
        {
            indicesGrupo1[t]=auxdos;   
        }
        //indice grupo dos
        if (Array.Exists(indicesGrupo2,x=>x==auxdos))
        {
            auxdos=buenas.Next(1,6);
            while (Array.Exists(indicesGrupo2,x=>x==auxdos))
            {
                auxdos=buenas.Next(1,6);
            }
            indicesGrupo2[t]=auxdos;
        }else
        {
            indicesGrupo2[t]=auxdos;   
        }
        //ya termine con el numero aleatorio de indices
        //muestro por pantalla ambos personajes que van a enfrentarse
        System.Console.WriteLine("Personaje 1:");
        System.Console.WriteLine("Los datos de el personaje son: ");
        System.Console.WriteLine("Armadura: "+ grupo1[indicesGrupo1[t]].Armadura);
        System.Console.WriteLine("Fuerza: "+grupo1[indicesGrupo1[t]].Fuerza);
        System.Console.WriteLine("Destreza: "+grupo1[indicesGrupo1[t]].Velocidad);
        System.Console.WriteLine("Nivel: "+grupo1[indicesGrupo1[t]].Nivel);
        System.Console.WriteLine("Salud: "+grupo1[indicesGrupo1[t]].Salud);
        System.Console.WriteLine("Edad: "+grupo1[indicesGrupo1[t]].Edad);
        System.Console.WriteLine("Tipo: "+grupo1[indicesGrupo1[t]].tipoDos);
        System.Console.WriteLine("Nombre: "+grupo1[indicesGrupo1[t]].Nombre);
        System.Console.WriteLine("Apodo: "+grupo1[indicesGrupo1[t]].Apodo);
        System.Console.WriteLine("Personaje2");
        System.Console.WriteLine("Los datos de el personaje son: ");
        System.Console.WriteLine("Armadura: "+ grupo2[indicesGrupo2[t]].Armadura);
        System.Console.WriteLine("Fuerza: "+grupo2[indicesGrupo2[t]].Fuerza);
        System.Console.WriteLine("Destreza: "+grupo2[indicesGrupo2[t]].Velocidad);
        System.Console.WriteLine("Nivel: "+grupo2[indicesGrupo2[t]].Nivel);
        System.Console.WriteLine("Salud: "+grupo2[indicesGrupo2[t]].Salud);
        System.Console.WriteLine("Edad: "+grupo2[indicesGrupo2[t]].Edad);
        System.Console.WriteLine("Tipo: "+grupo2[indicesGrupo2[t]].tipoDos);
        System.Console.WriteLine("Nombre: "+grupo2[indicesGrupo2[t]].Nombre);
        System.Console.WriteLine("Apodo: "+grupo2[indicesGrupo2[t]].Apodo);
        System.Console.WriteLine("Presiona 0 para iniciar el combate");
        control=Int32.Parse(Console.ReadLine());
        if (control!=0)
        {
            while (control!=0)
            {
                System.Console.WriteLine("Presiona 0 para iniciar el combate");
                control=Int32.Parse(Console.ReadLine());
            }   
        }
        control=1;
        //inicio de el combate, cada personaje va a realizar 3 ataques
        for (int h = 0; h < 3; h++)
        {

        }
    }
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