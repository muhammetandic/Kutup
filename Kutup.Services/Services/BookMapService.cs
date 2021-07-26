using Kutup.Core.Application.Interfaces;
using Kutup.Core.Application.Interfaces.Services;
using Kutup.Core.Domain.Entities;
using System.Collections.Generic;
using System.Xml;


namespace Kutup.Services.Services
{
    public class BookMapService : CrudServiceBase<BookMap>, IBookMapService
    {
        private readonly IGenericRepositoryAsync<BookMap> _repository;

        public BookMapService(IGenericRepositoryAsync<BookMap> repository) : base(repository)
        {
            _repository = repository;
        }

        public List<string> XmlGetNodes(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            string rootNode = doc.DocumentElement.Name.ToString();
            XmlNode node = doc.DocumentElement.FirstChild;
            return XmlGetNodesName(node, "");
        }

        private List<string> XmlGetNodeNames(XmlDocument doc, string rootNode)
        {
            List<string> fetchedNodeList = new List<string>();

            XmlNodeList nodeList = doc.SelectNodes(rootNode + "/*");

            foreach (XmlNode node in nodeList)
            {
                fetchedNodeList.Add(rootNode + "/" + node.Name);

                if (node.HasChildNodes)
                {
                    if (node.FirstChild.NodeType == XmlNodeType.Element)
                    {
                        rootNode += "/" + node.Name;
                        fetchedNodeList.AddRange(XmlGetNodeNames(doc, rootNode));
                    }
                }
            }

            return fetchedNodeList;
        }

        public List<string> XmlGetNodesName(XmlNode node, string nodePath)
        {

            var fetchedNodeList = new List<string>();
            while (node != null)
            {
                if (fetchedNodeList.IndexOf(nodePath + "/" + node.Name)==-1)
                {
                    fetchedNodeList.Add(nodePath + "/" + node.Name);
                }

                if (node.HasChildNodes)
                {
                    if (node.FirstChild.NodeType == XmlNodeType.Element)
                    {
                        var fetchedFromChild = XmlGetNodesName(node.FirstChild, nodePath + "/" + node.Name);
                        fetchedNodeList.AddRange(fetchedFromChild);
                    }
                }
                node = node.NextSibling;
            }

            XmlNode lastChild = node.LastChild;

            while (node != lastChild && node != null)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    fetchedNodeList.Add(nodePath + "/" + node.Name);
                    if (node.FirstChild != null)
                    {
                        if (node.FirstChild.NodeType == XmlNodeType.Element)
                        {
                            node = node.FirstChild;

                            List<string> fetchedFromChild = XmlGetNodesName(node, nodePath += "/" + node.ParentNode.Name);
                            fetchedNodeList.AddRange(fetchedFromChild);
                            break;
                        }
                    }
                    node = node.NextSibling;
                }
            }

            return fetchedNodeList;
        }
    }
}
