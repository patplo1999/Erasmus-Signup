import { Route, BrowserRouter as Router, Routes, Navigate } from "react-router-dom";
// Redux
import { useAppSelector } from "storage/redux/hooks";
import { RootState } from "storage/redux/store";
// Ant Design
import { Footer } from "antd/lib/layout/layout";
// Styles
import "./App.scss";
// Components
import LocationEventHandler from "components/LocationEventHandler";
import Navbar from "components/nav/Navbar";
import Unauthorized from "components/Unauthorized";
import NotFound from "components/NotFound";
import ListPageContainer from "pages/list/ListPageContainer";
import ProfilePageContainer from "pages/profile/ProfilePageContainer";
import HomePage from "pages/home/HomePage";
import DestinationDetailsPageContainer from "pages/destination-details/DestinationDetailsPageContainer";
import NotesPageContainer from "pages/notes/NotesPageContainer";

function App() {
  const { userLoggedIn } = useAppSelector((state: RootState) => state.login);

  return (
    <div className="app">
      <Router>
        <Navbar />
        <div className="layout">
          <Routes>
            <Route path="/" element={<Navigate replace to="/home" />} />
            <Route path="/home" element={<HomePage />} />
            <Route path="/list" element={<ListPageContainer />} />
            <Route path="/list/:code/:id" element={<DestinationDetailsPageContainer />} />
            <Route path="/profile" element={userLoggedIn ? <ProfilePageContainer /> : <Unauthorized />} />
            <Route path="/notes" element={userLoggedIn ? <NotesPageContainer /> : <Unauthorized />} />
            <Route path="*" element={<NotFound />} />
          </Routes>
          <Footer style={{ textAlign: "center" }}>Szampon Inc. Erasmus Sign-up</Footer>
        </div>
        <LocationEventHandler />
      </Router>
    </div>
  );
}

export default App;
