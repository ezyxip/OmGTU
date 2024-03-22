package dijkstra.graph

open class WeightedGraph {
    val edges = mutableSetOf<WeightedEdge>()
    open val vertexes get() = edges.flatMap { e -> e.vertexes }.toSet()
    val weight get() = edges.sumOf { it.weight }
    fun add(point1: Any, point2: Any, weight: Int){
        edges.add(WeightedEdge(Vertex(point1), Vertex(point2), weight))
    }
    fun add(point1: Vertex, point2: Vertex, weight: Int){
        edges.add(WeightedEdge(point1, point2, weight))
    }
    fun getRelated (vertex: Vertex): List<WeightedEdge> {
        return edges.filter { e -> e.vertexes.contains(vertex) }
    }

    fun getEdge(vertex1: Vertex, vertex2: Vertex): WeightedEdge {
        val res = edges.find { it.vertexes.containsAll(listOf(vertex1, vertex2)) }
            ?: throw Exception("Couldn't find edge")
        return res
    }

    fun getEdge(vertex1: Any, vertex2: Any): WeightedEdge = getEdge(Vertex(vertex1), Vertex(vertex2))
    fun add(edge: WeightedEdge) = edges.add(edge)
    override fun toString(): String {
        var res = "Graph{\n"
        for (i in edges) {
            res += i.toString() + "\n"
        }
        res += "}"
        return res
    }
}