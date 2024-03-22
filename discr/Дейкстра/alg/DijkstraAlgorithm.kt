package dijkstra.alg

import dijkstra.graph.Vertex
import dijkstra.graph.WeightedGraph

class DijkstraAlgorithm(private val graph: WeightedGraph, private val start: Vertex){
    private val container = DijkstraContainer(graph)
    init {
        container.setOption(start, mark = 0)
        recursive(start)
    }

    fun findPath(end: Vertex): WeightedGraph {
        val res = WeightedGraph()
        var current = container.get(end)
        while(current.from != start){
            if (current.from == null) throw Exception("Error")
            res.add(current, current.from!!, graph.getEdge(current, current.from!!).weight)
            current = container.get(current.from!!)
        }
        res.add(current, start, graph.getEdge(current, current.from!!).weight)
        return res
    }
    private fun recursive(vertex: Vertex){
        val current = container.get(vertex)
        val relatedEdges = graph.getRelated(vertex)
        for (edge in relatedEdges){
            val relatedVertex = container.get(edge.getOther(vertex))
            if(relatedVertex.isWorked) continue
            val newLabel = ModVertex(relatedVertex.name, current, current.mark!! + edge.weight, relatedVertex.isWorked)
            container.add(newLabel)
        }
        current.isWorked = true
        if (container.mods.find { e -> !e.isWorked && e.mark != null } != null){
            recursive(container.mods.find { e -> !e.isWorked && e.mark != null }!!)
        }
    }
}