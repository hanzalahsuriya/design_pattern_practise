using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Builder
{
    public class HtmlElement
    {
        public string Tag { get; set; }
        public string Text { get; set; }
        public List<HtmlElement> HtmlElements { get; set; } = new List<HtmlElement>();

        public HtmlElement()
        {
        }

        public HtmlElement(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException("argument is null");
            }

            this.Tag = tag;
        }

        public HtmlElement(string tag, string text) : this(tag)
        {
            this.Text = text;
        }

        private string ToStringImpl()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"<{Tag}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                stringBuilder.AppendLine(Text);
            }

            foreach (var e in this.HtmlElements)
            {
                stringBuilder.AppendLine(e.ToString());
            }

            stringBuilder.Append($"</{Tag}>");

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return this.ToStringImpl();
        }
    }

    public class HtmlBuilder
    {
        private string _rootTagName;
        private HtmlElement _rootElement;

        public HtmlBuilder(string root)
        {
            _rootTagName = root;
            _rootElement = new HtmlElement(root);
        }

        public HtmlBuilder AddChild(string tag, string text)
        {
            _rootElement.HtmlElements.Add(new HtmlElement(tag, text));
            return this;
        }

        public void Clear()
        {
            _rootElement = new HtmlElement(_rootTagName);
        }

        public override string ToString()
        {
            return _rootElement.ToString();
        }
    }

    public class HtmlBuilderExample
    {
        public static void Execute()
        {
            HtmlBuilder builder = new HtmlBuilder("ul");
            builder.AddChild("li", "word-1").AddChild("li", "word-2").AddChild("li", "word-3");

            Console.WriteLine(builder.ToString());
        }
    }
}