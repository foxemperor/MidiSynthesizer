using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using NAudio.Midi;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.IO;


namespace MidiSynthesizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MidiOut midiOut = new MidiOut(0);
        NoteLenghtTuples notes = new NoteLenghtTuples();
        int[] tmpArray = new int[3];
        private bool playFlag = false;
        private int selectedPatch = 0;
        private bool recordFlag = false;
        private Stopwatch stopwatch = new Stopwatch();
        private Dictionary<string, int> noteMap = new Dictionary<string, int>() 
        {
            { "C4", 60 },
            { "C4#", 61 },
            { "D4", 62 },
            { "D4#", 63 },
            { "E4", 64 },
            { "F4", 65 },
            { "F4#", 66 },
            { "G4", 67 },
            { "G4#", 68 },
            { "A4", 69 },
            { "A4#", 70 },
            { "B4", 71 },
            { "C5", 72 },
            { "C5#", 73 },
            { "D5", 74 },
            { "D5#", 75 },
            { "E5", 76 },
            { "F5", 77 },
            { "F5#", 78 },
            { "G5", 79 },
            { "G5#", 80 },
            { "A5", 81 },
            { "A5#", 82 },
            { "B5", 83 },
            { "C6", 84 }
        };
        private Dictionary<string, int> patchMap = new Dictionary<string, int>()
        {
            {"Пианино", 0},
            {"Электропианино", 4},
            {"Ксилофон", 13},
            {"Рок-орган", 19},
            {"Гитара", 24},
            {"Бас-гитара", 32},
            {"Скрипка", 41},
            {"Флейта", 74},
            {"Ocarina", 80}
        };
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RecordButtonClick(object sender, EventArgs e)
        {
            Button recordButton = (Button)sender;
            if (recordFlag == false)
            {
                recordButton.Background = Brushes.Red;
                recordButton.Content = "Идёт запись...";
                recordFlag = true;
            }
            else
            {
                recordButton.Background = Brushes.White;
                recordButton.Content = "Начать запись";
                recordFlag = false;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Serialize file(*.bin)|*.bin|Все файлы(*.*)|*.*";
                if (save.ShowDialog() != true) { return; }
                FileStream stream = new FileStream(save.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, notes);
                stream.Close();
            }
        }
        private void PianoButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            midiOut.Send(MidiMessage.StartNote(noteMap[clickedButton.Content.ToString()], 127, 1).RawData);
            Thread.Sleep(150);
            midiOut.Send(MidiMessage.StopNote(noteMap[clickedButton.Content.ToString()], 127, 1).RawData);
        }
        private void PatchComboBoxSelected(object sender, EventArgs e)
        {
            selectedPatch = patchMap[PatchComboBox.SelectedItem.ToString()];
            midiOut.Send(MidiMessage.ChangePatch(selectedPatch, 1).RawData);
        }
        private void KeyDownEventHandler(object sender, KeyEventArgs e)
        {
            if (playFlag == false && recordFlag == false)
            {
                switch (e.Key)
                {
                    case Key.Z: //C4
                        midiOut.Send(MidiMessage.StartNote(60, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.S: //C4#|
                        midiOut.Send(MidiMessage.StartNote(61, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.X: //D4
                        midiOut.Send(MidiMessage.StartNote(62, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.D: //D4#
                        midiOut.Send(MidiMessage.StartNote(63, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.C:  //E4
                        midiOut.Send(MidiMessage.StartNote(64, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.V: //F4
                        midiOut.Send(MidiMessage.StartNote(65, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.G: //F4#
                        midiOut.Send(MidiMessage.StartNote(66, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.B: //G4
                        midiOut.Send(MidiMessage.StartNote(67, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.H: //G4#
                        midiOut.Send(MidiMessage.StartNote(68, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.N: //A4
                        midiOut.Send(MidiMessage.StartNote(69, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.J: //A4#
                        midiOut.Send(MidiMessage.StartNote(70, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.M: //B4
                        midiOut.Send(MidiMessage.StartNote(71, 127, 1).RawData);
                        playFlag = true;
                        return;
                    //Вторая Октава
                    case Key.Q: //C5
                        midiOut.Send(MidiMessage.StartNote(72, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.D2: //C5#
                        midiOut.Send(MidiMessage.StartNote(73, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.W: //D5
                        midiOut.Send(MidiMessage.StartNote(74, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.D3: //D5#
                        midiOut.Send(MidiMessage.StartNote(75, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.E:  //E5
                        midiOut.Send(MidiMessage.StartNote(76, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.R: //F5
                        midiOut.Send(MidiMessage.StartNote(77, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.D5: //F5#
                        midiOut.Send(MidiMessage.StartNote(78, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.T: //G5
                        midiOut.Send(MidiMessage.StartNote(79, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.D6: //G5#
                        midiOut.Send(MidiMessage.StartNote(80, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.Y: //A5
                        midiOut.Send(MidiMessage.StartNote(81, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.D7: //A5#
                        midiOut.Send(MidiMessage.StartNote(82, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.U: //B5
                        midiOut.Send(MidiMessage.StartNote(83, 127, 1).RawData);
                        playFlag = true;
                        return;
                    case Key.I: //C6
                        midiOut.Send(MidiMessage.StartNote(84, 127, 1).RawData);
                        playFlag = true;
                        return;
                }
            }
            else if (playFlag == false && recordFlag == true)
            {
                stopwatch.Reset();
                stopwatch.Start();
                int msgStart;
                switch (e.Key)
                {
                    case Key.Z: //C4
                        msgStart = MidiMessage.StartNote(60, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.S: //C4#
                        msgStart = MidiMessage.StartNote(61, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.X: //D4
                        msgStart = MidiMessage.StartNote(62, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.D: //D4#
                        msgStart = MidiMessage.StartNote(63, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.C:  //E4
                        msgStart = MidiMessage.StartNote(64, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.V: //F4
                        msgStart = MidiMessage.StartNote(65, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.G: //F4#
                        msgStart = MidiMessage.StartNote(66, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.B: //G4
                        msgStart = MidiMessage.StartNote(67, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.H: //G4#
                        msgStart = MidiMessage.StartNote(68, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.N: //A4
                        msgStart = MidiMessage.StartNote(69, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.J: //A4#
                        msgStart = MidiMessage.StartNote(70, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.M: //B4
                        msgStart = MidiMessage.StartNote(71, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                        //Вторая Октава
                    case Key.Q: //C5
                        msgStart = MidiMessage.StartNote(72, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.Oem2: //C5#
                        msgStart = MidiMessage.StartNote(73, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.W: //D5
                        msgStart = MidiMessage.StartNote(74, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.Oem3: //D5#
                        msgStart = MidiMessage.StartNote(75, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.E:  //E5
                        msgStart = MidiMessage.StartNote(76, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.R: //F5
                        msgStart = MidiMessage.StartNote(77, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.Oem5: //F5#
                        msgStart = MidiMessage.StartNote(78, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.T: //G5
                        msgStart = MidiMessage.StartNote(79, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.Oem6: //G5#
                        msgStart = MidiMessage.StartNote(80, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.Y: //A5
                        msgStart = MidiMessage.StartNote(81, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.Oem7: //A5#
                        msgStart = MidiMessage.StartNote(82, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.U: //B5
                        msgStart = MidiMessage.StartNote(83, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                    case Key.I: //C6
                        msgStart = MidiMessage.StartNote(84, 127, 1).RawData;
                        midiOut.Send(msgStart);
                        tmpArray = new int[3];
                        tmpArray[0] = msgStart;
                        playFlag = true;
                        return;
                }
            }
        }
        public void StopAllNotes()
        {
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
            midiOut.Send(MidiMessage.StopNote(77, 127, 1).RawData);
            midiOut.Send(MidiMessage.StopNote(78, 127, 1).RawData);
            midiOut.Send(MidiMessage.StopNote(79, 127, 1).RawData);
            midiOut.Send(MidiMessage.StopNote(80, 127, 1).RawData);
            midiOut.Send(MidiMessage.StopNote(81, 127, 1).RawData);
            midiOut.Send(MidiMessage.StopNote(82, 127, 1).RawData);
            midiOut.Send(MidiMessage.StopNote(83, 127, 1).RawData);
            midiOut.Send(MidiMessage.StopNote(84, 127, 1).RawData);
        }
        private void KeyUpEventHandler(object sender, KeyEventArgs e)
        {
            if (recordFlag == false)
            {
                StopAllNotes();
                playFlag = false;
            }
            else if (recordFlag == true)
            {
                stopwatch.Stop();
                tmpArray[1] = (int)stopwatch.ElapsedMilliseconds + 250;
                tmpArray[2] = selectedPatch;
                StopAllNotes();
                playFlag = false;
                notes.NoteLenghtTupleList.AddLast(tmpArray);
            }
        }
        private void OpenSerializedButtonClick(object sender, EventArgs e)
        {
            midiOut.Close();
            midiOut.Dispose();
            NoteLenghtTuples playNotes = new NoteLenghtTuples();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Serialize file(*.bin)|*.bin|Все файлы(*.*)|*.*";
            if (open.ShowDialog() != true) { return; }
            FileStream stream = new FileStream(open.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            playNotes = (NoteLenghtTuples)bf.Deserialize(stream);
            stream.Close();
            SoundPlayer player = new SoundPlayer();
            player.PlayNotes(playNotes, selectedPatch);
            midiOut = new MidiOut(0);
        }
    }
}
