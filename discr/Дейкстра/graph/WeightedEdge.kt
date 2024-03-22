package dijkstra.graph

class WeightedEdge(point1: Vertex, point2: Vertex, val weight: Int)
    :Comparable<WeightedEdge>{
    val vertexes = setOf(point1, point2)

    fun getOther(vertex: Vertex): Vertex {
        for (i in vertexes){
            if (i != vertex) return i
        }
        throw Exception("Couldn't find vertex $vertex")
    }
    override fun compareTo(other: WeightedEdge): Int = weight.compareTo(other.weight)

    override fun equals(other: Any?): Boolean {
        if (this === other) return true
        if (javaClass != other?.javaClass) return false

        other as WeightedEdge

        if (weight != other.weight) return false
        if (vertexes != other.vertexes) return false

        return true
    }

    override fun hashCode(): Int {
        var result = weight
        result = 31 * result + vertexes.hashCode()
        return result
    }

    override fun toString(): String {
        val vertexes = this.vertexes.toList()
        return "${vertexes[0].name} --${weight}-- ${vertexes[1].name}"
    }

}