using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tekla.Structures.Drawing
{
    class DrawingList2
    {
        /// <summary>Opens drawing list window</summary>
        public static void ShowDrawingListWindow()
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();
                akit.Callback("gdr_menu_select_active_draw", "", "main_frame");
                akit.Run();
                akit = null;
            }
        }

        /// <summary>Closing drawing list window</summary>
        public static void CloseDrawingListWindow()
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();
                akit.PushButton("dia_draw_select_cancel", "Drawing_selection");
                akit.Run();
                akit = null;
            }
        }

        /// <summary>Show all drawings on the list. Every avaiable drawings on the model</summary>
        public static void ShowAllDrawings()
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();
                akit.PushButton("dia_draw_display_all", "Drawing_selection");
                akit.Run();
                akit = null;
            }
        }

        /// <summary>
        /// Selects drawing on the opened drawing list window
        /// </summary>
        /// <param name="indexOnTheList">1-based index</param>
        public static void SelectDrawingOnTheList(int indexOnTheList)
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();

                akit.TableSelect("Drawing_selection", "dia_draw_select_list", indexOnTheList);

                akit.Run();
                akit = null;
            }
        }

        /// <summary>Selects drawing on the opened drawing list</summary>
        /// <param name="fromIndex">1-based index of first drawing from selection</param>
        /// <param name="toIndex">1-based index of last drawing from selection</param>
        public static void SelectDrawingOnTheList(int fromIndex, int toIndex)
        {
            if (fromIndex < 1) return;
            if (toIndex < fromIndex) return;

            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();
                int drCount = new Tekla.Structures.Drawing.DrawingHandler().GetDrawings().GetSize();
                int tableSize = toIndex - fromIndex + 1;
                tableSize = Math.Min(drCount, tableSize);
                int[] selectDrawings = new int[tableSize];
                int fromIndex2 = fromIndex;

                for (int i = 0; i < tableSize; i++)
                {
                    selectDrawings[i] = fromIndex2;
                    fromIndex2++;
                }

                akit.TableSelect("Drawing_selection", "dia_draw_select_list", selectDrawings);

                akit.Run();
                akit = null;
            }
        }

        /// <summary>Selects every drawing on the list</summary>
        public static void SelectAllDrawings()
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();
                int drCount = new Tekla.Structures.Drawing.DrawingHandler().GetDrawings().GetSize();
                int[] selectDrawings = new int[drCount];

                for (int i = 0; i < drCount; i++)
                {
                    selectDrawings[i] = i + 1;
                }

                akit.TableSelect("Drawing_selection", "dia_draw_select_list", selectDrawings);

                akit.Run();
                akit = null;
            }
        }

        /// <summary>Clear drawing selection from drawing list. Unselects all selected drawings</summary>
        public static void UnselectAllDrawings()
        {
            if(Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();

                akit.TableSelect("Drawing_selection", "dia_draw_select_list");

                akit.Run();
                akit = null;
            }
        }
    }
}
