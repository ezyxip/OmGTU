package com.ezyxip

class WeightedGraph {
    val edges = mutableSetOf<WeightedEdge>()
    val vertexes get() = edges.flatMap { e -> e.vertexes }.toSet()
    val weight get() = edges.sumOf { it.weight }
    fun add(point1: Any, point2: Any, weight: Int){
        edges.add(WeightedEdge(Vertex(point1), Vertex(point2), weight))
    }
    fun add(point1: Vertex, point2: Vertex, weight: Int){
        edges.add(WeightedEdge(point1, point2, weight))
    }
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

class WeightedEdge(point1: Vertex, point2: Vertex, val weight: Int)
    :Comparable<WeightedEdge>{
    val vertexes = setOf(point1, point2)
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

class Vertex(designation: Any) {
    val name = designation.toString()
    override fun toString(): String {
        return name
    }
    override fun equals(other: Any?): Boolean {
        if (this === other) return true
        if (javaClass != other?.javaClass) return false

        other as Vertex

        return name == other.name
    }

    override fun hashCode(): Int {
        return name.hashCode()
    }

}