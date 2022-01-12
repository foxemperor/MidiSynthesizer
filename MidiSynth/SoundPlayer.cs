using System;
using System.Threading;
using NAudio.Midi;

namespace MidiSynthesizer
{
    public class SoundPlayer
    {
        private MidiOut midiOut;
        public NoteLenghtTuples NotesForPlaying { get; private set; }
        public SoundPlayer() { }
        public void PlayNotes(NoteLenghtTuples notes, int patch)
        {
            if (patch > 127 || patch < 0)
            {
                throw new ArgumentOutOfRangeException("Некорректный номер инструмента");
            }
            midiOut = new MidiOut(0);
            midiOut.Send(MidiMessage.ChangePatch(patch, 1).RawData);
            foreach (int[] arr in notes.NoteLenghtTupleList)
            {
                midiOut.Send(arr[0]);
                Thread.Sleep(arr[1]);
                Thread.Sleep(100);
                midiOut.Send(MidiMessage.StopNote(60, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(61, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(62, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(63, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(64, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(65, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(66, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(67, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(68, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(69, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(70, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(71, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(72, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(73, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(74, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(75, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(76, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(77, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(78, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(79, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(80, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(81, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(82, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(83, 127, 1).RawData);
                midiOut.Send(MidiMessage.StopNote(84, 127, 1).RawData);
            }
            midiOut.Close();
            midiOut.Dispose();
        }
    }
}
