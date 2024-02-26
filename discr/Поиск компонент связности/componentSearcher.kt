
fun main() {
    println("Hello World")
    val graph = Graph()
    println("Введите количество рёбер графа")
    val count = readLine()!!.toInt()
    for(i in 1..count){
        println("Ребро номер $i:")
        print("Введите первую вершину: ")
        val point1 = readLine()!!
        print("Введите вторую вершину: ")
        val point2 = readLine()!!
        graph.add(point1, point2)
    }
    
    println(searchComponents(graph).joinToString("\n"))
}

fun searchComponents(graph: Graph): Set<Graph>{
    var vertices = graph.vertexes
    var currentVertex = vertices.getOne()
    val res = mutableSetOf<Graph>()
    while(true){
        val component: Graph = ComponentSearcher(currentVertex, graph).getComponent()
        res.add(component)
        vertices = vertices.subtract(component.vertexes)
        if(vertices.isEmpty()) break
        currentVertex = vertices.getOne()
    }
    return res
}

fun Set<Vertex>.getOne(): Vertex{
    return this.first()
}

class ComponentSearcher(
    val vertex: Vertex,
    val graph: Graph
){
    private val resultGraph = Graph()
    
    fun getComponent(): Graph{
        getComponent(vertex)
        return resultGraph
    }
    
    private fun getComponent(vertex: Vertex){
        val edges = graph.getConnectedEdges(vertex)
        for(edge in edges){
            if (resultGraph.edges.contains(edge)) continue
            resultGraph.add(edge)
            getComponent(edge.getConnectedVertex(vertex)!!)
        }
    }
    
    fun Graph.getConnectedEdges(vertex: Vertex): Set<Edge>{
        return edges.filter {e -> e.vertexes.contains(vertex) }.toSet()
    }
    
    fun Edge.getConnectedVertex(vertex: Vertex): Vertex?{
        return vertexes.subtract(setOf(vertex)).first()
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

class Graph {
    val edges = mutableSetOf<Edge>()
    val vertexes get() = edges.flatMap { e -> e.vertexes }.toSet()
    fun add(point1: Any, point2: Any){
        edges.add(Edge(Vertex(point1), Vertex(point2)))
    }
    fun add(point1: Vertex, point2: Vertex){
        edges.add(Edge(point1, point2))
    }
    fun add(edge: Edge) = edges.add(edge)
    override fun toString(): String {
        var res = "Graph{\n"
        for (i in edges) {
            res += i.toString() + "\n"
        }
        res += "}"
        return res
    }
}

class Edge(point1: Vertex, point2: Vertex){
    val vertexes = setOf(point1, point2)

    override fun toString(): String {
        val vertexes = this.vertexes.toList()
        return "${vertexes[0].name} -- ${vertexes[1].name}"
    }

}
