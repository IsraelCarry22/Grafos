using System;
using System.Collections.Generic;
using Grafos.Clases;

class Program
{
    static void Main()
    {
        #region Rutas mas cortas
        Console.WriteLine("=== La ruta mas corta es? ===");
        RoutesGraph Graph = new RoutesGraph();
        Graph.AddRoutes("A", "B", 10);
        Graph.AddRoutes("B", "C", 5);
        Graph.AddRoutes("A", "C", 20);
        int distance = Graph.CalculateShortestRoute("A", "C");
        Console.WriteLine("La distancia más corta entre A y C es: " + distance);
        Console.WriteLine("=============================\n");
        #endregion

        #region Red_Social
        Console.WriteLine("=== Red Social ===");
        SocialNetwork Network = new SocialNetwork();
        Network.AddFriend("Usuario1", "Amigo1");
        Network.AddFriend("Usuario1", "Amigo2");
        Network.AddFriend("Usuario2", "Amigo2");
        Network.AddFriend("Usuario2", "Amigo3");
        List<string> Suggestions = Network.GetSuggestedFriends("Usuario1");
        Console.WriteLine("Amigos sugeridos para Usuario1:");
        foreach (var friend in Suggestions)
        {
            Console.WriteLine(friend);
        }
        Console.WriteLine("=============================\n");
        #endregion

        #region Dependencias_de_Código
        Console.WriteLine("=== Proyecto ===");
        SoftwareProject project = new SoftwareProject();
        project.AddDependence("ModuloA", "ModuloB");
        project.AddDependence("ModuloB", "ModuloC");
        project.AddDependence("ModuloC", "ModuloA");
        bool Cycles = project.DependencyCycles();
        Console.WriteLine("El proyecto tiene ciclos de dependencia: " + Cycles);
        Console.WriteLine("=============================\n");
        #endregion

        Console.ReadKey();
    }
}
