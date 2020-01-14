# Tekla-Structures-API-Snippets
Set of my classes and methods, which extends Tekla Structures API 

Projects do not contains any Tekla.Structures API dll files, because its need the licensed copy of application Tekla Structures.

# Project content

**namespace Tekla.Structures.Drawing:**

	**DrawingList2** - usefull methods to manipulate the drawing list (old Tekla Structures drawing list not document manager)

	**MultiDrawing2** - some multi drawing methods

	**SortPointsFromView2** - usefull methods to get points from the point list in the view. Very usefull when making dimmensions algotithms

**namespace Tekla.Strucutres.Drawing.Automation:**

	**DrawingCreator2** - drawing creations methods

**namespace Tekla.Structures.Geometry3d**

	**Intersection2** - added missing methods for creating intersection

**namespace Tekla.Structures.Model.Operations**

	**Operation2** - methods to save, close, open, split, combine methods which are missing in original class

# How can you use it?

I recommend to copy files to your project. Because of different api versions of TS this is the most safe method.
You can also compile project and add dll file as a reference, but it is not tested yet.

