using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tekla.Structures.Geometry3d;
using TSM = Tekla.Structures.Model;

namespace Tekla.Structures.Model.Operations
{
    class Operation2
    {
        ///Still in work not tested
        public static void Split(List<Beam> listOfObjects, Point splitPoint)
        {
            foreach (Beam beam in listOfObjects)
            {
                Tekla.Structures.Model.Operations.Operation.Split(beam, splitPoint);
            }
        }
        //TODO test
        ///Still in work not tested
        public static void Combine(List<Beam> beamList)
        {
            if (beamList.Count == 0) return;

            var beamToDeleteList = new List<Beam>();
            Beam beam = beamList[0];
            
            for (int i = 1; i < beamList.Count; i++)
            {
                try
                {
                    var vectorFromStartToEnd = new Vector(beam.EndPoint - beamList[i].StartPoint);
                    var vectorFromStartToStart = new Vector(beam.StartPoint - beamList[i].StartPoint);

                    var vectorFromEndToEnd = new Vector(beam.EndPoint - beamList[i].EndPoint);
                    var vectorFromEndToStart = new Vector(beam.StartPoint - beamList[i].EndPoint);

                    var angle1 = vectorFromStartToEnd.GetAngleBetween(vectorFromStartToStart);
                    var angle2 = vectorFromEndToEnd.GetAngleBetween(vectorFromEndToStart);

                    if ((Math.Abs(Math.PI - angle1) < 0.1) && (Math.Abs(Math.PI - angle2) < 0.1))
                    {
                        beamToDeleteList.Add(beamList[i]);
                    }
                    else
                    {
                        beam = Tekla.Structures.Model.Operations.Operation.Combine(beam, beamList[i]);
                    }

                }
                catch (Exception)
                {
                    break;
                }
            }

            foreach (var b in beamToDeleteList)
            {
                b.Delete();
            }
        }

        /// <summary>Create current model autosave</summary>
        public static void AutoSaveModel()
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();
                akit.Callback("acmd_autosave_model", "", "main_frame");
                akit.Run();
                akit = null;
            }
        }

        ///<summary>Save current model</summary>
        public static void SaveModel()
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();
                akit.Callback("acmd_save_model", "", "main_frame");
                akit.Run();
                akit = null;
            }
        }

        //TODO check something wrong with 3d views
        ///<summary>Reopen current model</summary>
        public static void ReopenModel(bool loadAutosave = true)
        {
            Tekla.Structures.Model.Operations.Operation.Open(new TSM.Model().GetInfo().ModelPath, loadAutosave);
        }
    }
}
