using System;
using System.ComponentModel.Composition;

namespace MetaResolutionIssue.Meta
{
    [MetadataAttribute]
    public class MetaAttribute : Attribute, IMeta
    {
        public MetaAttribute(string value) => this.Value = value;

        public string Value { get; private set; }
    }
}
