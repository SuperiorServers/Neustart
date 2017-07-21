using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neustart
{
    /* 
     * Format:
     * {
     *      ID: string,
     *      Enabled: boolean,
     *      Hidden: boolean,
     *      Path: string,
     *      Args: string,
     *      Affinities: int,
     *      Priority: int,
     *      PID: int,
     *      HWND: int,
     *      StartTime: string,
     *      Crashes: int
     * }
     */
    public class AppConfig
    {
        public static  event EventHandler OnConfiguationChanged;

        private string m_ID, m_Path, m_Args;
        private DateTime m_StartTime;
        private bool m_Enabled, m_Hidden;
        private int m_Affinities, m_Priority, m_PID, m_HWND, m_Crashes;

        [JsonProperty]
        public string ID { get { return m_ID; } set { m_ID = value; Save(); } }
        [JsonProperty]
        public string Path { get { return m_Path; } set { m_Path = value; Save(); } }
        [JsonProperty]
        public string Args { get { return m_Args; } set { m_Args = value; Save(); } }
        [JsonProperty]
        public DateTime StartTime { get { return m_StartTime; } set { m_StartTime = value; Save(); } }
        [JsonProperty]
        public bool Enabled { get { return m_Enabled; } set { m_Enabled = value; Save(); } }
        [JsonProperty]
        public bool Hidden { get { return m_Hidden; } set { m_Hidden = value; Save(); } }
        [JsonProperty]
        public int Affinities { get { return m_Affinities; } set { m_Affinities = value; Save(); } }
        [JsonProperty]
        public int Priority { get { return m_Priority; } set { m_Priority = value; Save(); } }
        [JsonProperty]
        public int PID { get { return m_PID; } set { m_PID = value; Save(); } }
        [JsonProperty]
        public int HWND { get { return m_HWND; } set { m_HWND = value; Save(); } }
        [JsonProperty]
        public int Crashes { get { return m_Crashes; } set { m_Crashes = value; Save(); } }

        public AppConfig()
        {
            m_PID = -1;
            m_HWND = -1;
            m_Crashes = 0;
        }

        public void Save()
        {
            OnConfiguationChanged?.Invoke(this, null);
        }
    }
}
