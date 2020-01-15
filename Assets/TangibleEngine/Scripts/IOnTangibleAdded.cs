﻿namespace TE {
  public interface IOnTangibleAdded {
    /// <summary>
    /// Called when a new tangible has been added
    /// </summary>
    /// <param name="t">The new tangible instance</param>
    void OnTangibleAdded(Tangible t);
  }
}