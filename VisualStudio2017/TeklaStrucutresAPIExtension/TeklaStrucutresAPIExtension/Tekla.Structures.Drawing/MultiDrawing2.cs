using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tekla.Structures.Drawing
{
    class MultiDrawing2
    {
        /// <summary>
        /// Links drawing from the drawing list to the opened multi drawing
        /// </summary>
        /// <param name="indexOnTheList">1-based index</param>
        public static void LinkDrawing(int indexOnTheList)
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var dh = new DrawingHandler();
                if (!dh.GetConnectionStatus()) return;
                if (dh.GetActiveDrawing() == null) return;
                if (!(dh.GetActiveDrawing() is Tekla.Structures.Drawing.MultiDrawing)) return;

                var akit = new Tekla.Structures.MacroBuilder();

                akit.TableSelect("Drawing_selection", "dia_draw_select_list", indexOnTheList);
                akit.Callback("acmd_include_drawing_views", "link_no_placing", "Drawing_selection");

                akit.Run();
                akit = null;
            }
        }
    }
}
