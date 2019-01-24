using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tekla.Structures.Drawing.Automation
{
    class DrawingCreator2
    {
        ///<summary>Creates empty multidrawing</summary>
        public static void CreateMultiDrawing()
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();

                akit.Callback("acmd_create_multi_assembly_drawing", "", "main_frame");

                akit.Run();
                akit = null;
            }
        }

        ///<summary>Creates single part drawings from selected parts in the model. Loads "standard" attributes from file. 
        ///If nothing selected then no drawings will be created</summary>
        public static void CreateSinglePartDrawingsFromSelection()
        {
            CreateSinglePartDrawingsFromSelection("standard");
        }

        ///<summary>Creates single part drawings from selected parts in the model. Loads attributes from file. File name without extension.
        ///If nothing selected then no drawings will be created</summary>
        public static void CreateSinglePartDrawingsFromSelection(string attributeFileName)
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();

                akit.Callback("acmd_display_attr_dialog", "wdraw_dial", "main_frame");
                akit.ValueChange("wdraw_dial", "gr_wdraw_get_menu", attributeFileName);
                akit.PushButton("gr_wdraw_get", "wdraw_dial");
                akit.PushButton("gr_wdraw_apply", "wdraw_dial");
                akit.PushButton("gr_wdraw_ok", "wdraw_dial");
                akit.Callback("acmd_create_dim_part_drawings", "", "main_frame");

                akit.Run();
                akit = null;
            }
        }

        ///<summary>Creates assembly drawings from selected parts in the model. Loads "standard" attributes from file. 
        ///If nothing selected then no drawings will be created</summary>
        public static void CreateAssemblyDrawingsFromSelection()
        {
            CreateAssemblyDrawingsFromSelection("standard");
        }

        ///<summary>Creates assembly drawings from selected parts in the model. Loads attributes from file. File name without extension.
        ///If nothing selected then no drawings will be created</summary>
        public static void CreateAssemblyDrawingsFromSelection(string attributeFileName)
        {
            if (Tekla.Structures.TeklaStructures.Connect())
            {
                var akit = new Tekla.Structures.MacroBuilder();

                akit.Callback("acmd_display_attr_dialog", "adraw_dial", "main_frame");
                akit.ValueChange("adraw_dial", "gr_adraw_get_menu", attributeFileName);
                akit.PushButton("gr_adraw_get", "adraw_dial");
                akit.PushButton("gr_adraw_apply", "adraw_dial");
                akit.PushButton("gr_adraw_ok", "adraw_dial");
                akit.Callback("acmd_create_dim_assembly_drawings", "", "main_frame");

                akit.Run();
                akit = null;
            }
        }

    }
}
