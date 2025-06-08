using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentProject
{
    internal class Menu
    {
        public AgentDAL agentSystem = new AgentDAL();
        public Dictionary<int, string> menu = new Dictionary<int, string>
        {
            {1, "Enter Id"},
            {2, "Enter a code name"},
            {3, "Enter the real name"},
            {4, "enter the name of the city"},
            {5, "enter a status"},
            {6, "missions completed"},
        };

        public Menu()
        {
            agentSystem.OpenProgram();
        }

        public void displayMenu()
        {
            Console.WriteLine("Enter your choos!");
            string choos = Console.ReadLine();
            switch(choos)
            {
                case "Add":
                    for(int i = 1; i <= menu.Count(); i++)
                    {
                        Console.WriteLine(menu[i]);
                        menu[i] = Console.ReadLine();

                    }
                    Agent agent = new Agent(Convert.ToInt32(menu[1]), menu[2], menu[3], menu[4], menu[5], Convert.ToInt32(menu[6]));
                    agentSystem.AddAgent(agent);
                    break;
                case "Update":
                    Console.WriteLine("Please enter the id");
                    int UPid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the new location.");
                    string newLocation = Console.ReadLine();
                    agentSystem.UpdateAgentLocation(UPid, newLocation);
                    break;
                case "Delete":
                    Console.WriteLine("Please enter the id");
                    int Delid = Convert.ToInt32(Console.ReadLine());
                    agentSystem.DeleteAgent(Delid);
                    break;
                case "Show":
                    agentSystem.GetAllAgents();
                    agentSystem.ReadAgents();
                    break;

            }

            agentSystem.CloseProgram();
        }
    }
}
