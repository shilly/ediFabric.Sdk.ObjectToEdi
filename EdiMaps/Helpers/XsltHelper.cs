using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace EdiFabric.Sdk.ObjectToEdi.EdiMaps.Helpers
{
    public class XslHelper
    {
        public static byte[] ExecuteCompiledXslMap(Type map, byte[] from)
        {
            Debug.Assert(map != null);
            Debug.Assert(from != null);

            if (map == null)
                throw new ArgumentException("map");

            if (from == null)
                throw new ArgumentException("from");


            var transform = new XslCompiledTransform();
            transform.Load(map);

            IXPathNavigable documentFrom = new XPathDocument(new MemoryStream(from));
            var to = new MemoryStream();

            transform.Transform(documentFrom, XmlWriter.Create(to, transform.OutputSettings)); // this preserves settings like cdata out

            if (to == null)
                throw new InvalidOperationException("Expected valid output stream after transform for map type " + map);

            to.Seek(0, SeekOrigin.Begin);

            return to.ToArray();
        }

        internal static byte[] ToByte(XElement instance)
        {
            using (var ms = new MemoryStream())
            {
                instance.Save(ms);
                ms.Position = 0;
                return ms.ToArray();
            }
        }

        public static T Deserialize<T>(XElement xml, string nameSpace)
        {
            var serializer = new XmlSerializer(typeof(T), nameSpace);
            return (T)serializer.Deserialize(xml.CreateReader());
        }

        public static XElement Serialize<T>(T instance, string ns)
        {
            var type = instance.GetType();

            var serializer = new XmlSerializer(type, ns);
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, instance);
                ms.Position = 0;
                return XElement.Load(ms, LoadOptions.None);
            }
        }
    }
}
