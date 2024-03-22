package dijkstra.graph

open class Vertex(designation: Any) {
    val name = designation.toString()
    override fun toString(): String {
        return name
    }
    override fun equals(other: Any?): Boolean {
        if (this === other) return true

        other as Vertex

        return name == other.name
    }

    override fun hashCode(): Int {
        return name.hashCode()
    }

}