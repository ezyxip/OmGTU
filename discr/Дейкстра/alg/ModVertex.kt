package dijkstra.alg

import dijkstra.graph.Vertex

class ModVertex(
    designation: Any,
    var from: Vertex?,
    var mark: Int?,
    var isWorked: Boolean
) : Vertex(designation)