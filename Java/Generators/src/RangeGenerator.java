/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Neal
 */
public class RangeGenerator implements Generator<Integer> {
   private int mStart, mEnd;
   private int mCurrent;
   
   public RangeGenerator(int start, int end) {
      mStart = start;
      mEnd = end;
      mCurrent = mStart;
   }
   
   public boolean hasNext() {
      return mCurrent <= mEnd;
   }
   
   public Integer next() {
      System.out.println("Generating " + mCurrent);
      return mCurrent++;
   }
}