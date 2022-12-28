import { configureStore, ThunkAction, Action } from "@reduxjs/toolkit";
import { persistReducer, FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER } from "redux-persist";
import storage from "redux-persist/lib/storage";
// Slices
import universitySlice from "./universitySlice";
import loginSlice from "./userSlice";
import userCurrentSlice from "./userCurrentSlice";
import noteSlice from "./noteSlice";

const loginPersistConfig = {
  key: "login",
  storage,
  whitelist: ["userLoggedIn"],
};

export const store = configureStore({
  reducer: {
    university: universitySlice,
    note: noteSlice,
    login: persistReducer(loginPersistConfig, loginSlice)!,
    userCurrent: userCurrentSlice,
  },
  devTools: process.env.NODE_ENV !== "production",
  middleware: getDefaultMiddleware =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      },
    }),
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<ReturnType, RootState, unknown, Action<string>>;
