using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WillWin.Models
{
    public class LoginViewModel
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Aim { get; set; }
    }
}
