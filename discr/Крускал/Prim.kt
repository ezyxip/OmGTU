package com.ezyxip

fun primAlgorithm(graph: WeightedGraph){
    val vertexes = graph.vertexes

}

fun WeightedGraph.getIncidentalEdges(vertex: Vertex): MutableSet<WeightedEdge> {
    var res = mutableSetOf<WeightedEdge>()
    edges.forEach {if(it.vertexes.contains(vertex)) res.add(it)}
    return res
}