using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order66exe.Models
{
    public class RuleModel
    {
        public int RuleId { get; set; }
        //'true' for text channel; 'false' for voice channel
        public bool Chat { get; set; }
        public string Description { get; set; }

        public RuleModel() { }

        public RuleModel(bool chat, string desc)
        {
            Chat = chat;
            Description = desc;
        }

    }
}
