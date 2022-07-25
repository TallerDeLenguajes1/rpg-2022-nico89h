using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
const int MaximoDanoProvocable=5000;
List<Personaje> grupo1= new List<Personaje>();
List<Personaje> grupo2= new List<Personaje>();
//System.Console.WriteLine("Como queres que se carguen los personajes? 1-aleatoriamente, 2-json");
//int boton=Int32.Parse(Console.ReadLine());
int boton=2;
//incio el guardado de los datos en las listas para personajes aleatorios
if (boton==1)
{
    Personaje grupo= new Personaje();
    for (int i = 0; i < 4; i++)
    {
        grupo=cargarDatos();
        grupo1.Insert(i,new Personaje{Nombre=grupo.Nombre,Apodo=grupo.Apodo,FechaNacimiento=grupo.FechaNacimiento, Salud=100, tipoDos=grupo.tipoDos});    
        grupo1[i].aleatorios();
        grupo1[i].valores();
        //inidices en el ola de 0 a 3
    }
    //int m=0;
    for (int e = 0; e < 4; e++)
    {
        //indice de 4 a 7
        grupo=cargarDatos();
        grupo2.Insert(e,new Personaje{Nombre=grupo.Nombre,Apodo=grupo.Apodo,FechaNacimiento=grupo.FechaNacimiento,Salud=100, tipoDos=grupo.tipoDos});
        grupo2[e].aleatorios();
        grupo2[e].valores();
    }    
}else //guardado de personajes a traves de json
{
    string auxLeer= File.ReadAllText("jugadores.json");
    var desiarilizacion= JsonSerializer.Deserialize<List<Personaje>>(auxLeer);
    for (int i = 0; i < 4; i++) //primer cargado de el grupo 1
    {
        grupo2.Insert(i,new Personaje{Velocidad=desiarilizacion[i].Velocidad,Destreza=desiarilizacion[i].Destreza,Fuerza=desiarilizacion[i].Fuerza,Nivel=desiarilizacion[i].Nivel,Armadura=desiarilizacion[i].Armadura,tipoDos=desiarilizacion[i].tipoDos,Nombre=desiarilizacion[i].Nombre,Apodo=desiarilizacion[i].Apodo,FechaNacimiento=desiarilizacion[i].FechaNacimiento,Edad=desiarilizacion[i].Edad,Salud=100});
        
    }
    int e=0;
    for (int i = 4; i < 8; i++) //cargado de el grupo 2
    {
        grupo1.Insert(e,new Personaje{Velocidad=desiarilizacion[i].Velocidad,Destreza=desiarilizacion[i].Destreza,Fuerza=desiarilizacion[i].Fuerza,Nivel=desiarilizacion[i].Nivel,Armadura=desiarilizacion[i].Armadura,tipoDos=desiarilizacion[i].tipoDos,Nombre=desiarilizacion[i].Nombre,Apodo=desiarilizacion[i].Apodo,FechaNacimiento=desiarilizacion[i].FechaNacimiento,Edad=desiarilizacion[i].Edad,Salud=100});
        e++;
    }
}






//fin de el guardado de datos

int controlApi;
System.Console.WriteLine("Quiere ver o visualizar los valores de la api? Presione 0 para ver");
controlApi=Int32.Parse(Console.ReadLine());
if (controlApi==0)
{
    
}





//





Random indice1=new Random();
Random indice2=new Random();
List<bool> controles= new List<bool>();
controles=control(8); // comienzo de todos los jugadores
int indiceUno;
int indiceDos;
int cantidadPeleas=4;
int comienzo=0;
int auxDos;
int cantidad=0;
List<Personaje> Resultados= new List<Personaje>();
List<Personaje> ResultadosDos= new List<Personaje>();

for (int i = 0; i < 3; i++) // son en total 3, los rounds  
{
    if (i==0) //primera iteracion, utilizo los valores de los grupos
    {
        System.Console.WriteLine("Inicio de los octavos");
        for (int t = 0; t < cantidadPeleas; t++) // realizo las pelea de cada round
        {
            //relizo el control si es que se uso un elemento o no;
            System.Console.WriteLine("Pelea numero: "+t+1);
            do      
            {
                indiceUno=indice1.Next(0,4);
                indiceDos=indice2.Next(4,8);
            }while(!controles[indiceUno] && !controles[indiceDos]);
            //indico cuales indices ya fueron usados
            controles[indiceUno]=false;
            controles[indiceDos]=false;
            switch (indiceDos)
            {
                case 4:
                    indiceDos=0;
                    break;
                case 5:
                    indiceDos=1;
                    break;
                case 6:
                    indiceDos=2;
                    break;
                default:
                    indiceDos=3;
                    break;
            }
            //comienzo la batalla entre los dos personajes seleccionados en cada round
            int siguienteGolpe;
            System.Console.WriteLine("La batalla esta por empezar");
            for (int e = 0; e < 6 && grupo1[indiceUno].Salud>0 && grupo2[indiceDos].Salud>0; e++) // cantidad de ataques de cada personaje
            {
                //hago un random de el atacante inicial
                //la variable comienzo indica cual de los dos atacantes empezara
                if (comienzo==0)
                {
                    auxDos=indice1.Next(1,3);
                }else
                {    
                    do
                    {
                        auxDos=indice1.Next(1,3);
                    } while (comienzo!=auxDos);   
                }
                comienzo=auxDos;
                if(comienzo==1){ //el primer atacante pertenece a el grupo1
                    grupo2[indiceDos].Salud=grupo2[indiceDos].Salud-(MecanicaCombate(grupo1[indiceUno],grupo2[indiceDos]));
                }else //el segundo atacante es del grupo 2
                {
                    grupo1[indiceUno].Salud=grupo1[indiceUno].Salud-(MecanicaCombate(grupo2[indiceDos],grupo1[indiceUno]));
                }
            }
            //inicio el guardado de los personajes ganadores
            if (grupo1[indiceUno].Salud==grupo1[indiceUno].Salud)
            {
                auxDos=indice1.Next(1,3);
                comienzo=auxDos;
                if(comienzo==1){ //el primer atacante pertenece a el grupo1
                    grupo2[indiceDos].Salud=0;
                }else //el segundo atacante es del grupo 2
                {
                    grupo1[indiceUno].Salud=0;
                }
            }
            if (grupo1[indiceUno].Salud<=0)
            {
                System.Console.WriteLine("Ganador de el round: "+ grupo1[indiceUno].tipoDos);
                Resultados.Insert(cantidad,new Personaje{Nombre=grupo2[indiceDos].Nombre,Apodo=grupo2[indiceDos].Apodo,FechaNacimiento=grupo2[indiceDos].FechaNacimiento, Salud=100, tipoDos=grupo2[indiceDos].tipoDos});
                Resultados[cantidad].aleatorios();
                Resultados[cantidad].valores();
                cantidad++;//sera el indice de resultado
            }else if(grupo2[indiceDos].Salud<=0){
                System.Console.WriteLine("Ganador de el round: "+ grupo2[indiceDos].tipoDos);                
                Resultados.Insert(cantidad,new Personaje{Nombre=grupo1[indiceUno].Nombre,Apodo=grupo1[indiceUno].Apodo,FechaNacimiento=grupo1[indiceUno].FechaNacimiento, Salud=100,tipoDos=grupo1[indiceUno].tipoDos});
                Resultados[cantidad].aleatorios();
                Resultados[cantidad].valores();
                cantidad++;
            }else if (grupo1[indiceUno].Salud>grupo2[indiceDos].Salud)
            {
                System.Console.WriteLine("Ganador de el round: "+ grupo1[indiceUno].tipoDos);
                Resultados.Insert(cantidad,new Personaje{Nombre=grupo1[indiceUno].Nombre,Apodo=grupo1[indiceUno].Apodo,FechaNacimiento=grupo1[indiceUno].FechaNacimiento,Salud=100, tipoDos=grupo1[indiceUno].tipoDos});
                Resultados[cantidad].aleatorios();
                Resultados[cantidad].valores();
                cantidad++;
            }else if(grupo2[indiceDos].Salud>grupo1[indiceUno].Salud)
            {
                System.Console.WriteLine("Ganador de el round: "+ grupo2[indiceDos].tipoDos);
                Resultados.Insert(cantidad,new Personaje{Nombre=grupo2[indiceDos].Nombre,Apodo=grupo2[indiceDos].Apodo,FechaNacimiento=grupo2[indiceDos].FechaNacimiento, Salud=100,tipoDos=grupo2[indiceDos].tipoDos });
                Resultados[cantidad].aleatorios();
                Resultados[cantidad].valores();
                cantidad++;
            }
        }   
    }else //en caso de que hayan pasado la primera ronda,uso los ganadores
    {
        if (cantidadPeleas==1) //la final de todo, se decidira el ganador Total
        {
            System.Console.WriteLine("Inicio de el combate final");
            for (int e = 0; e < 6 && ResultadosDos[0].Salud>0 && ResultadosDos[1].Salud>0; e++) // cantidad de ataques de cada personaje
            {
                //hago un random de el atacante inicial
                do
                {
                    auxDos=indice1.Next(0,2);
                } while (comienzo!=auxDos);
                comienzo=auxDos;
                if(comienzo==1){ //el primer atacante pertenece a el Resultados
                    ResultadosDos[1].Salud=ResultadosDos[1].Salud-(MecanicaCombate(ResultadosDos[0],ResultadosDos[1]));
                }else //el segundo atacante es del grupo 2
                {
                    ResultadosDos[0].Salud=ResultadosDos[0].Salud-(MecanicaCombate(ResultadosDos[1],ResultadosDos[0]));
                }
            }
            //inicio de el ganador Total
            //caso de que haya un empate
            if (ResultadosDos[0].Salud==ResultadosDos[1].Salud)
            {
                auxDos=indice1.Next(1,3);
                comienzo=auxDos;
                if(comienzo==1){//el primer atacante pertenece a el grupo1
                    ResultadosDos[0].Salud=0;
                }else //el segundo atacante es del grupo 2
                {
                    ResultadosDos[1].Salud=0;
                }
            }
            //caso de que no hay un empate

            if (ResultadosDos[0].Salud<=0)
            {
                mostrarGanador(ResultadosDos[1]);   
            }else if(ResultadosDos[1].Salud<=0){
                mostrarGanador(ResultadosDos[0]);
            }else if (ResultadosDos[0].Salud>ResultadosDos[1].Salud)
            {
                mostrarGanador(ResultadosDos[0]);
            }else if(ResultadosDos[1].Salud>ResultadosDos[0].Salud)
            {
                mostrarGanador(ResultadosDos[1]);
            }
        }else
        {
            System.Console.WriteLine("Inicio de Las semis finales");
            for (int t = 0; t < cantidadPeleas; t++) // realizo la pelea de cada round
            {
                //relizo el control si es que se uso un elemento o no;
                do
                {
                    indiceUno=indice1.Next(0,2);
                    indiceDos=indice2.Next(2,4);
                }while(!controles[indiceUno] && !controles[indiceDos]);
                
                //indico cuales indices ya fueron usados
                controles[indiceUno]=false;
                controles[indiceDos]=false;
                //comienzo la batalla entre los dos personajes seleccionados en cada round
                for (int e = 0; e < 6 && Resultados[indiceUno].Salud>0 && Resultados[indiceDos].Salud>0; e++) // cantidad de ataques de cada personaje
                {
                    //hago un random de el atacante inicial
                    do
                    {
                        auxDos=indice1.Next(1,3);
                    } while (comienzo!=auxDos);
                    comienzo=auxDos;
                    if(comienzo==1){ //el primer atacante pertenece a el Resultados
                        Resultados[indiceDos].Salud=Resultados[indiceDos].Salud-(MecanicaCombate(Resultados[indiceUno],Resultados[indiceDos]));
                    }else //el segundo atacante es del grupo 2
                    {
                        Resultados[indiceUno].Salud=Resultados[indiceUno].Salud-(MecanicaCombate(Resultados[indiceDos],Resultados[indiceUno]));
                    }
                }
                //inicio el guardado de los personajes ganadores
                //hay un empate en la salud de ambos personajes
                if (Resultados[indiceUno].Salud==Resultados[indiceDos].Salud)
                {
                    //el ganador sera de manera aleatorio
                    do
                    {
                        auxDos=indice1.Next(1,3);
                    } while (comienzo!=auxDos);
                    comienzo=auxDos;
                    if(comienzo==1){ //el primer atacante pertenece a el Resultados
                        Resultados[indiceDos].Salud=0;
                    }else //el segundo atacante es del grupo 2
                    {
                        Resultados[indiceUno].Salud=0;
                    }
                }
                //no hay un empate
                if (Resultados[indiceUno].Salud<=0)
                {
                    System.Console.WriteLine("El ganador de el round es : "+ Resultados[indiceUno].tipoDos);
                    ResultadosDos.Insert(cantidad,new Personaje{Nombre=Resultados[indiceDos].Nombre,Apodo=Resultados[indiceDos].Apodo,FechaNacimiento=Resultados[indiceDos].FechaNacimiento, tipoDos=Resultados[indiceDos].tipoDos, Salud=100});
                    ResultadosDos[cantidad].aleatorios();
                    ResultadosDos[cantidad].valores();
                    cantidad++;
                }else if(Resultados[indiceDos].Salud<=0){
                    System.Console.WriteLine("El ganador de el round es : "+ Resultados[indiceDos].tipoDos);
                    ResultadosDos.Insert(cantidad,new Personaje{Nombre=Resultados[indiceUno].Nombre,Apodo=Resultados[indiceUno].Apodo,FechaNacimiento=Resultados[indiceUno].FechaNacimiento,tipoDos=Resultados[indiceUno].tipoDos, Salud=100});
                    ResultadosDos[cantidad].aleatorios();
                    ResultadosDos[cantidad].valores();
                    cantidad++;
                }else if (Resultados[indiceUno].Salud>Resultados[indiceDos].Salud)
                {
                    System.Console.WriteLine("El ganador de el round es : "+ Resultados[indiceUno].tipoDos);
                    ResultadosDos.Insert(cantidad,new Personaje{Nombre=Resultados[indiceUno].Nombre,Apodo=Resultados[indiceUno].Apodo,FechaNacimiento=Resultados[indiceUno].FechaNacimiento,tipoDos=Resultados[indiceUno].tipoDos, Salud=100});
                    ResultadosDos[cantidad].aleatorios();
                    ResultadosDos[cantidad].valores();
                    cantidad++;
                }else if(Resultados[indiceDos].Salud>Resultados[indiceUno].Salud)
                {
                    System.Console.WriteLine("El ganador de el round es : "+ Resultados[indiceDos].tipoDos);
                    ResultadosDos.Insert(cantidad,new Personaje{Nombre=Resultados[indiceDos].Nombre,Apodo=Resultados[indiceDos].Apodo,FechaNacimiento=Resultados[indiceDos].FechaNacimiento, tipoDos=Resultados[indiceDos].tipoDos, Salud=100});
                    ResultadosDos[cantidad].aleatorios();
                    ResultadosDos[cantidad].valores();
                    cantidad++;
                }
            }    
        }
        
    }
    cantidadPeleas=cantidadPeleas/2;
    controles=control(cantidadPeleas*2);
    cantidad=0;
}







//inicio de funciones

//funcion para obtener la salud del personaje
int MecanicaCombate(Personaje atacante, Personaje defensor){
    int siguienteGolpe=0;
    do
    {
        System.Console.WriteLine("Apreta un numero para comenzar el ataque que sea distinto de 0");
        siguienteGolpe=Int32.Parse(Console.ReadLine());
    } while (siguienteGolpe==0);
    int PoderDisparo=atacante.Destreza* atacante.Fuerza* atacante.Nivel;
    Random aleatorio=new Random();
    int efectividadDisparo=aleatorio.Next(1,101);
    int valorAtaque=PoderDisparo*efectividadDisparo;
    int poderDefensa=defensor.Armadura*defensor.Velocidad;
    int danoProvocado=(((valorAtaque*efectividadDisparo)-poderDefensa)/MaximoDanoProvocable)*100;
    System.Console.WriteLine("El "+ atacante.tipoDos+" ataco a :"+ defensor.tipoDos);
    System.Console.WriteLine("Restandole a el mismo : "+ danoProvocado);
    return danoProvocado;
}
//inicializo la lista en true, donde va a representar lo que es los indices de los personajes
List<bool> control(int cantidad){
    List<bool> aux=new List<bool>();
    for (int i = 0; i < cantidad; i++)
    {
        aux.Insert(i,true);
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
    int auxTiposdos=auxTipos.Next(1,6);
    switch (auxTiposdos)
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
    grupo.Salud=100;
    return grupo;
}
void mostrarGanador(Personaje ganador){
    //inicio de mostrar ganador
    System.Console.WriteLine("El ganador Total, de todos ");
    System.Console.WriteLine("Obteniendo el TRONO DE HIERRO, es: ....");
    System.Console.WriteLine(ganador.tipoDos);
    System.Console.WriteLine("Cuyo nombre es: "+ ganador.Nombre);
    System.Console.WriteLine("Salud: "+ ganador.Salud);
    System.Console.WriteLine("Edad: "+ ganador.Edad);
    System.Console.WriteLine("Apodo"+ ganador.Apodo);
    System.Console.WriteLine("Caracteristicas: ");
    System.Console.WriteLine("Destreza"+ ganador.Destreza);
    System.Console.WriteLine("Velocidad"+ ganador.Velocidad);
    System.Console.WriteLine("Fuerza"+ ganador.Fuerza);
    System.Console.WriteLine("Armadura"+ ganador.Armadura);
    System.Console.WriteLine("Fin del juego.");
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
        set{
            velocidad=value;
        }
    }
    private int destreza;
    public int Destreza{
        get{
            return destreza;
        }
        set{
            destreza=value;
        }
    }
    private int fuerza;
    public int Fuerza{
        get{
            return fuerza;
        }
        set{
            fuerza=value;
        }
    }
    private int nivel;
    public int Nivel{
        get{
            return nivel;
        }
        set{
            nivel=value;
        }
    }
    private int armadura;
    public int Armadura{
        get{
            return armadura;
        }
        set{
            armadura=value;
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
        set{
            edad=value;
        }
    }
    private int salud;
    public int Salud{
        get{
            return salud;
        }
        set{
            salud=value;
        }
    }
    private Random aux=new Random();
    public void aleatorios(){
        this.edad=aux.Next(0,300);
    }
}