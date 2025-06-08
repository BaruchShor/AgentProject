using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentProject
{
    internal class AgentDAL
    {
        private string connStr = "server=localhost;username=root;password=;database=eagleEyedb";
        private string _query;
        private MySqlConnection _conn;
        private MySqlCommand cmd;
        public List<Agent> allAgents = new List<Agent>();

        private void eagleEyeDBConnection()
        {
            this._conn = new MySqlConnection(connStr);
        }

        public AgentDAL()
        {
            eagleEyeDBConnection();
            //this._conn.Open();
        }
        public void AddAgent(Agent agent)
        {
            this._conn.Open();
            try
            {
                this._query = "INSERT INTO agents (id,codeName,realName,location,status,missionsCompleted) VALUES (@Id,@CodeName,@RealName,@Location,@Status,@MissionsCompleted)";
                cmd = new MySqlCommand(this._query, this._conn);
                cmd.Parameters.AddWithValue("@id", agent.Id);
                cmd.Parameters.AddWithValue("@codeName", agent.CodeName);
                cmd.Parameters.AddWithValue("@realName", agent.RealName);
                cmd.Parameters.AddWithValue("@location", agent.Location);
                cmd.Parameters.AddWithValue("@status", agent.Status);
                cmd.Parameters.AddWithValue("@missionsCompleted", agent.MissionsCompleted);
                cmd.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"no no no {ex.Message}");
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<Agent> GetAllAgents()
        {
            this._conn.Open();
            this._query = "SELECT * FROM agents";
            this.cmd = new MySqlCommand(this._query, this._conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string codeName = reader.GetString("codeName");
                string realName = reader.GetString("realName");
                string location = reader.GetString("location");
                string status = reader.GetString("status");
                int missionsCompleted = reader.GetInt32("missionsCompleted");
                allAgents.Add(new Agent(id, codeName, realName, location, status, missionsCompleted));
            }
            this._conn.Close();
            return allAgents;
        }

        public void ReadAgents()
        {
            foreach(Agent agent in allAgents)
            {
                Console.WriteLine($"id : {agent.Id}\n name:{agent.RealName}");
            }
        }

        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            this._conn.Open();
            try
            {
                this._query = $"UPDATE agents SET location = @newLocation WHERE id = @agentId";
                this.cmd = new MySqlCommand(this._query, this._conn);
                cmd.Parameters.AddWithValue("@newLocation", newLocation);
                cmd.Parameters.AddWithValue("@agentId", agentId);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"NO NO NO {ex.Message}");
            }
            finally
            {
                this._conn.Close();
            }
        }
        public void DeleteAgent(int agentId)
        {
            this._conn.Open();
            try
            {
                this._query = $"DELETE FROM agents WHERE id = @agentId";
                this.cmd = new MySqlCommand(this._query, this._conn);
                cmd.Parameters.AddWithValue("@agentId", agentId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"NO NO NO {ex.Message}");
            }
            finally
            {
                this._conn.Close();
            }
        }

        public void ProgramManager()
        {
            try
            {
                
            }
            catch (MySqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            finally{

            }
        }

    }
}
