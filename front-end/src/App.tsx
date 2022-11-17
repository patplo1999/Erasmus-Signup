import { Layout } from "antd";
import { Footer } from "antd/lib/layout/layout";
import Navbar from "components/nav/Navbar";
import ListPageContainer from "pages/list/ListPageContainer";
import ProfilePageContainer from "pages/profile/ProfilePageContainer";
import LoginPageContainer from "pages/login/LoginPageContainer";
import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import "./App.scss";
import ExampleHomePage from "./pages/home/ExampleHomePage";

function App() {
  return (
    <div className="app">
      <Router>
        <Layout className="layout">
          <Navbar />
          <Routes>
            <Route path="/" element={<ExampleHomePage />} />
            <Route path="/list" element={<ListPageContainer />} />
            <Route path="/login" element={<LoginPageContainer />} />
            <Route path="/profile" element={<ProfilePageContainer />} />
          </Routes>
          <Footer style={{ textAlign: "center" }}>
            Ant Design ©2018 Created by Ant UED
          </Footer>
        </Layout>
      </Router>
    </div>
  );
}

export default App;
