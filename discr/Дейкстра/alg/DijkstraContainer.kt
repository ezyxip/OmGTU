package dijkstra.alg

import dijkstra.graph.Vertex
import dijkstra.graph.WeightedGraph

class DijkstraContainer (graph: WeightedGraph){

    val mods: MutableSet<ModVertex> = graph.vertexes
        .map { e -> ModVertex(e, null, null, false) }
        .toMutableSet()

    fun add (vertex: ModVertex){
        for (i in mods){
            if (i.name == vertex.name){
                if (i.mark == null){
                    i.mark = vertex.mark
                    i.from = vertex.from
                }else if (i.mark!! > vertex.mark!!){
                    i.mark = vertex.mark
                    i.from = vertex.from
                }
                return
            }
        }
        throw Exception("Error")
    }

    fun get(vertex: String): ModVertex {
        for (i in mods){
            if (i.name == vertex){
                return i
            }
        }
        throw Exception("Error")
    }

    fun get(vertex: Vertex): ModVertex {
        return get(vertex.name)
    }
    fun setOption (name: String, from: Vertex? = null, mark: Int? = null, isWorked: Boolean? = null){
        var target: ModVertex? = null
        for (i in mods){
            if (i.name == name){
                target = i
            }
        }
        if (target == null) throw Exception("Error")

        if(from != null) target.from = from
        if(mark != null) target.mark = mark
        if(isWorked != null) target.isWorked = isWorked
    }

    fun setOption (vertex: Vertex, from: Vertex? = null, mark: Int? = null, isWorked: Boolean? = null){
        setOption(vertex.name, from, mark, isWorked)
    }

    override fun toString(): String {
        return "Dijkstra(mods=$mods)"
    }


}


