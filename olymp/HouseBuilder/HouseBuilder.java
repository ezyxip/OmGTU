public class Main
{
    static int[][] inputs = new int[][]{
        {3,4,5,10,4,7,6,6,3},
        {6,7,5,10,4,7,6,6,3},
        {3,4,5,10,4,16,6,6,3},
        {6,6,5,10,4,16,6,6,3},
        {3,4,5,12,4,7,6,6,3},
        {6,6,5,12,4,7,6,6,3},
        {3,4,5,20,4,17,6,6,3}
    };
    
    static int[] output = new int[]{159, 302, 167, 278, 163, 283, 203};
    
	public static void main(String[] args) {
	    
	    for(int i = 0; i < inputs.length; i++){
    	    int result = 0;
    	    
    		int x = inputs[i][0], y = inputs[i][1], L = inputs[i][2], c1 = inputs[i][3], c2 = inputs[i][4], c3 = inputs[i][5], c4 = inputs[i][6], c5 = inputs[i][7], c6 = inputs[i][8];
    		
    		int longestWall = Math.max(x, y);
        	int remainingLPart = L - longestWall;
        	if (remainingLPart > 0) {
        	    result += c2 * remainingLPart;
        	} else {
        	    remainingLPart = 0;
        	}
        	
        	int newWalls = 2 * x + 2 * y - L;
        	int newWallsPrice = newWalls * (c4 + c5);
        	
        	int oldWallPriceRepair = (L - remainingLPart) * c1;
        	int oldWallPriceRecompose = (L - remainingLPart) * (c2 + c3);
        	int oldWallPriceReplace = (L - remainingLPart) * (c2 + c5 + c4 + c6);
        	
        	int oldWallLowestPrice = Math.min(oldWallPriceRepair, oldWallPriceRecompose);
        	oldWallLowestPrice = Math.min(oldWallLowestPrice, oldWallPriceReplace);
        	    
        	result += newWallsPrice + oldWallLowestPrice;
        	
    	    int smallPartRecomposePrice = remainingLPart * c3;
    	    int replaceWithNewPrice = remainingLPart * (c4 + c5 + c6);
    	    int lowestPriceCase = Math.min(smallPartRecomposePrice, replaceWithNewPrice);
    	    result += lowestPriceCase;
        	
        	System.out.println(result);
	    }
	    
	    
	}
}
