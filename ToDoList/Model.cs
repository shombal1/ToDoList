using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoList
{   
    public class Model
    {
        [JsonProperty(PropertyName ="chek")]
        public bool chek { get; set; }
        [JsonProperty(PropertyName ="texTask")]
        public string text { get; set; }
        [JsonProperty(PropertyName ="timeCreateTask")]
        public DateTime dateTime { get; set; }=DateTime.Now;
    }
}
