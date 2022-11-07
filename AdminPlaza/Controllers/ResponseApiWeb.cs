using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPlaza.Controllers
{
    public class ResponseApiWeb
    {
        public ResponseApiWeb()
        {

        }

        public ResponseApiWeb(string _Message, string _MessageDetail)
        {
            MessageDetail = _MessageDetail;
            Code = _Message;
            isError = true;
        }
        public ResponseApiWeb(string _Message)
        {

            MessageDetail = _Message;
            Code = "COD-000";
            isError = false;
        }
        public string Code { get; set; }
        public string MessageDetail { get; set; }
        public bool  isError { get; set; }

    }
}