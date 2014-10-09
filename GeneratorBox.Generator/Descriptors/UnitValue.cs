﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorBox.Generator
{
    [Serializable]
    public class UnitValue : MarshalByRefObject
    {
        public UnitValue()
        {
            Properties = new List<Property>();
            Fields = new List<Field>();
        }

        public string Namespace { get; set; }
        
        public string ClassName { get; set; }

        public IList<Property> Properties { get; set; }
        public IList<Field> Fields { get; set; }
    }
}