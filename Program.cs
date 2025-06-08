using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AgentDAL agentDAL = new AgentDAL();
            agentDAL.DeleteAgent(1);
            agentDAL.GetAllAgents();
            agentDAL.ReadAgents();
        }
    }
}
