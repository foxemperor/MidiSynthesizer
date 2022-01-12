using System;
using System.Collections.Generic;

namespace MidiSynthesizer
{
    [Serializable]
    public class NoteLenghtTuples
    {
        public LinkedList<int[]> NoteLenghtTupleList { get; private set; }
        public NoteLenghtTuples()
        {
            NoteLenghtTupleList = new LinkedList<int[]>();
        }
        public void ClearList()
        {
            NoteLenghtTupleList.Clear();
        }
    }
}
