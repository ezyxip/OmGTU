package com.ezyxip

class KruskalPool {
    private val sets: MutableList<MutableSet<Vertex>> = mutableListOf()
    val resultGraph: WeightedGraph = WeightedGraph()
    fun addEdge(weightedEdge: WeightedEdge){
        val inner = weightedEdge.vertexes.flatMap { e -> searchVertex(e) }
        if (inner.isEmpty()){
            sets.add(weightedEdge.vertexes.toMutableSet())
            resultGraph.add(weightedEdge)
        } else if (inner.size == 1) {
            sets[inner[0]].addAll(weightedEdge.vertexes)
            resultGraph.add(weightedEdge)
        } else if (inner.size == 2 && (inner[0] != inner[1])){
            sets[inner[0]].addAll(sets[inner[1]])
            sets.removeAt(inner[1])
            resultGraph.add(weightedEdge)
        }
    }

    private fun searchVertex(vertex: Vertex): List<Int> {
        val listOfSets = mutableListOf<Int>()
        sets.forEachIndexed {
                index, vertices ->
            if (vertices.contains(vertex)) listOfSets.add(index)
        }
        return listOfSets
    }
}

fun kruskalAlgorithm(graph: WeightedGraph): WeightedGraph {
    val edges = graph.edges.sorted()
    val pool = KruskalPool()
    for(edge in edges){
        pool.addEdge(edge)
    }
    return pool.resultGraph
}