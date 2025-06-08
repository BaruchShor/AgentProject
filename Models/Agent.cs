using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentProject
{
    internal class Agent
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int MissionsCompleted { get; set; }

        string[] statusArr = { "Active", "Injured", "Missing", "Retired" };

        public Agent(int id, string codeName, string realName, string location, string status, int missionsCompleted)
        {
            this.Id = id;
            this.CodeName = codeName;
            this.RealName = realName;
            this.Location = location;
            this.Status = status;
            this.MissionsCompleted = missionsCompleted;
        }

        public string validateStatus(string status)
        {
            string agentStatus = status;
            while(!statusArr.Contains(status))
            {
                Console.WriteLine("Pleas enter a correct status!");
                agentStatus = Console.ReadLine();
            }
            return agentStatus;
        }
    }
}
