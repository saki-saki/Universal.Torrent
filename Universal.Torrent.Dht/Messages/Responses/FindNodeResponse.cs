#if !DISABLE_DHT
//
// FindNodeResponse.cs
//
// Authors:
//   Alan McGovern <alan.mcgovern@gmail.com>
//
// Copyright (C) 2008 Alan McGovern
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


using Universal.Torrent.Bencoding;
using Universal.Torrent.Dht.Messages.Queries;
using Universal.Torrent.Dht.Nodes;

namespace Universal.Torrent.Dht.Messages.Responses
{
    internal class FindNodeResponse : ResponseMessage
    {
        private static readonly BEncodedString NodesKey = "nodes";

        public FindNodeResponse(NodeId id, BEncodedValue transactionId)
            : base(id, transactionId)
        {
            Parameters.Add(NodesKey, new BEncodedString());
        }

        public FindNodeResponse(BEncodedDictionary d, QueryMessage m)
            : base(d, m)
        {
            
        }

        public BEncodedString Nodes
        {
            get
            {
                return (BEncodedString) Parameters[NodesKey];
            }
            set { Parameters[NodesKey] = value; }
        }

        public override void Handle(DhtEngine engine, Node node)
        {
            base.Handle(engine, node);
            engine.Add(Node.FromCompactNode(Nodes.TextBytes));
        }
    }
}

#endif