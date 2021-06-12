using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_CARO_2
{
    [Serializable]
    public class SocketData
    {
        private int command;

        public int Command
        {
            get { return command; }
            set { command = value; }
        }

        private Point point;

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [JsonConstructor]
        public SocketData(int command, string message, Point point)
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
        }

        public SocketData(int command, Point point )
        {
            this.Command = command;
            this.Point = point;
            this.Message = "";
        }

        public SocketData(int command, string message)
        {
            this.Command = command;
            this.Point = new Point();
            this.Message = message;
        }
        public SocketData(int command)
        {
            this.Command = command;
            this.Point = new Point();
            this.Message = "";
        }
    }

    public class SocketCommand
    {
        /*public const int SEND_POINT = 200;
        public const int NOTIFY = 201;
        public const int NEW_GAME = 202;
        public const int UNDO = 203;
        public const int END_GAME = 204;
        public const int QUIT = 205;
        public const int TIME_OUT = 206;*/

        /*daa chua phan 130 do di*/
        public const int CSEND_NAME = 000;
        /*public const int SREP_NAME_VALID = 010;*/
        public const int SREP_NAME_INVALID = 011;
        public const int SSEND_LIST_PLAYER = 100;
        public const int CSEND_OPNAME = 110;

        public const int SREP_OPSTATUS_UNAVAI = 120;
        /*public const int SREP_OPSTATUS_AVAI = 121;
        public const int CCFED_OP = 130;*/

        public const int SSEND_CHALLENGE = 140;
        public const int CREP_CHALLENGE_ACCEPT = 150; // khi op accepted thi gui order cho hai ben luon
        public const int CREP_CHALLENGE_DENY = 151;
        public const int SFORW_CHALLENGE_DENY = 160;

        public const int SNOTI_ORDER_FIRST = 200;
        public const int SNOTI_ORDER_SECOND = 201;

        public const int CSENT_TURN = 210;
        public const int SFORW_TURN = 220;

        public const int CREP_TURN_INVALID  = 250;
        public const int SFORW_TURN_INVALID = 260;

        /*public const int CSENT_TURN_FIRST = 210;
        public const int CSENT_TURN_SECOND = 211;
        public const int SFORW_TURN_FIRST = 220;
        public const int SFORW_TURN_SECOND = 220;*/

        public const int CSENT_QUIT = 230;
        public const int SFORW_QUIT = 270;

        /*public const int CSENT_QUIT_FIRST = 230;
        public const int CSENT_QUIT_SECOND = 231;*/

        public const int CSENT_WIN = 240;
        public const int SFORW_WIN = 280;


    }
}
