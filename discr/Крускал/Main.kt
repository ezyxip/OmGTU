package com.ezyxip

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
    println(kruskalAlgorithm(graph))
    println(kruskalAlgorithm(graph).weight)
}