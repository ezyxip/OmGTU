package dijkstra

import dijkstra.graph.Vertex
import dijkstra.graph.WeightedGraph
import dijkstra.alg.DijkstraAlgorithm

fun main() {
    println("Hello World!")
    val graph = WeightedGraph()
    print("Введите количество рёбер: ")
    val countOfEdge = readln().toInt()
    println("Вводите рёбра в виде v1--weight--v2")
    for (i in 0..<countOfEdge){
        val input = readln().split("--")
        graph.add(input[0], input[2], input[1].toInt())
    }
    print("Введите начальную вершину: ")
    val start = Vertex(readln())
    print("Введите, куда необходимо проложить маршрут: ")
    val end = Vertex(readln())

    println(DijkstraAlgorithm(graph, start).findPath(end))
}