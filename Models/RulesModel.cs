using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order66exe.Models
{
    public class RulesModel
    {
        public int RuleId { get; set; }
        //'true' for text channel; 'false' for voice channel
        public bool Chat { get; set; }
        public string Description { get; set; }

        public RulesModel() { }

        public RulesModel(bool chat, string desc)
        {
            Chat = chat;
            Description = desc;
        }
    }
}
