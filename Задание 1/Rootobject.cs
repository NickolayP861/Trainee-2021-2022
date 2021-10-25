namespace JSON_to_html
{

    public class Rootobject
    {
        public Form form { get; set; }
    }

    public class Form
    {
        public string name { get; set; }
        public string postmessage { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string type { get; set; }
        public Attributes attributes { get; set; }
    }

    public class Attributes
    {
        public string message { get; set; }
        public string name { get; set; }
        public string placeholder { get; set; }
        public bool required { get; set; }
        public string value { get; set; }
        public string label { get; set; }
        public string _class { get; set; }
        public Validationrule[] validationRules { get; set; }
        public bool disabled { get; set; }
    }

    public class Validationrule
    {
        public string type { get; set; }
    }
}
